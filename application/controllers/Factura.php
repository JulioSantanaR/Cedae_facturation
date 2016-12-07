<?php
	class Factura extends CI_Controller
	{
		public function __construct()
		{
			parent::__construct();
			$this->load->database();
		}
		
		public function Facturar()
		{					
			date_default_timezone_set('America/Mexico_City');
			$rfc = $this->input->post('rfc');
			$razon = $this->input->post('razon');
			$pais = $this->input->post('pais');
			$estado = $this->input->post('estado');
			$municipio = $this->input->post('municipio');
			$colonia = $this->input->post('colonia');
			$calle = $this->input->post('calle');
			$cp = $this->input->post('cp');
			$noexterno = $this->input->post('noexterno');
			$correo = $this->input->post('correo');
			$tickets = $this->input->post('tickets');
			$listClient = $this->ClientModel->GetClient($rfc);
			$listTickets = $this->TicketModel->GetTickets($tickets);
			
			/********** Comienza Object Seguridad **********/
			//Traer desde BD
			$pass = 'test123$';
			$hex = strtoupper($this->encryptPass($pass));
			$Seguridad = array (
			   '0' => 'test',
			   '1' => $hex
			);
			$Seguridad = (object) $Seguridad;
			
			/********** Comienza Object Comprobante **********/
			$descuentoProducto = 0;
			$descuentoServicio = 0;
			$formaPagoProducto = '';
			$formaPagoServicio = '';
			foreach($listTickets as $ticket)
			{
				if($ticket->isService == 0)
				{
					$descuentoProducto += (double) $ticket->descuentoQuantity;
				}
				else
				{
					$descuentoServicio += (double) $ticket->descuentoQuantity;
				}
			}

			foreach($listTickets as $ticket)
			{
				if($ticket->isService == 0)
				{
					$formaPagoSAT = $this->GetMethodPaySAT($ticket->formaPago);
					if(!strpos($formaPagoProducto,$formaPagoSAT))
					{
						$formaPagoProducto .= $formaPagoSAT.",";
					}
				}
				else
				{
					$formaPagoSAT = $this->GetMethodPaySAT($ticket->formaPago);
					if(!strpos($formaPagoServicio,$this->GetMethodPaySAT($ticket->formaPago)))
					{
						$formaPagoServicio .= $formaPagoSAT.",";
					}
				}
			}
			
			//Object Comprobante Producto
			if($descuentoProducto > 0)
			{
				$haveDiscountProduct = 'Descuento producto';
			}
			else
			{
				$haveDiscountProduct = '';
			}
			$formaPagoProducto = rtrim($formaPagoProducto, ',');
			$comprobanteProducto = array (
			   '0' => date("Y-m-d H:i:s"),
			   '1' => '30 días',
			   '2' => $descuentoProducto,
			   '3' => $haveDiscountProduct,
			   '4' => $formaPagoProducto,
			   '5' => '1',
			   '6' => 'MXN',
			   '7' => 'CDMX',
			   '8' => ''
			);
			$comprobanteProductoObject = (object) $comprobanteProducto;
			
			//Object Comprobante Servicio
			if($descuentoServicio > 0)
			{
				$haveDiscountService = 'Descuento servicio';
			}
			else
			{
				$haveDiscountService = '';
			}
			$formaPagoServicio = rtrim($formaPagoServicio, ',');
			$comprobanteServicio = array (
			   '0' => date("Y-m-d H:i:s"),
			   '1' => '30 días',
			   '2' => $descuentoProducto,
			   '3' => $haveDiscountService,
			   '4' => $formaPagoServicio,
			   '5' => '1',
			   '6' => 'MXN',
			   '7' => 'CDMX',
			   '8' => ''
			);
			$comprobanteServicioObject = (object) $comprobanteServicio;
			
			/********** Comienza Object Receptor **********/
			foreach($listClient as $client)
			{
				$receptor = array (
					'0' => $client->rfc,
					'1' => $client->razonsocial,
					'2' => $client->calle,
					'3' => $client->noexterno,
					'4' => $client->nointerno,
					'5' => $client->colonia,
					'6' => $client->municipio,
					'7' => '',
					'8' => $client->estado,
					'9' => $client->pais,
					'10' => $client->cp
				);
			}
			$receptorObject = (object) $receptor;
			
			/********** Comienza Object Emisor **********/
			foreach($listTickets as $ticket)
			{
				$emisor = array (
					'0' => $ticket->idsucursal
				);
			}
			$emisorObject = (object) $emisor;
			
			/********** Comienza Object Conceptos e Impuestos **********/
			foreach($listTickets as $ticket)
			{
				//Productos
				if($ticket->isService == 0)
				{
					//Conceptos Producto
					$conceptosProducto[] = array (
						'0' => $ticket->cantidad,
						'1' => 'Producto',
						'2' => $ticket->item_id,
						'3' => $ticket->nombre,
						'4' => $ticket->totalitem,
						'5' => $ticket->totalSinIVA
					);					
					//Impuestos Producto
					$impuestosProducto[] = array (
						'0' => 'IVA',
						'1' => $ticket->IVA,
						'2' => $ticket->totalItemsIVA
					);
				}
				//Servicios
				else
				{
					//Conceptos Servicios
					$conceptosServicio[] = array (
						'0' => $ticket->cantidad,
						'1' => 'Servicio',
						'2' => $ticket->item_id,
						'3' => $ticket->nombre,
						'4' => $ticket->totalitem,
						'5' => $ticket->totalSinIVA
					);
					//Impuestos Producto
					$impuestosServicio[] = array (
						'0' => 'IVA',
						'1' => $ticket->IVA,
						'2' => $ticket->totalItemsIVA
					);
				}
			}
			$conceptosProductoObject = (object) $conceptosProducto;
			$impuestosProductoObject = (object) $impuestosProducto;
			$conceptosServicioObject = (object) $conceptosServicio;
			$impuestosServicioObject = (object) $impuestosServicio;
			
			/********** Comienzan Peticiones al Web Service **********/
			//Si hay productos hacemos factura de otro modo vamos al caso de facturar un servicio
			if(count($conceptosProductoObject) > 0)
			{	
				$params = array(
					'Seguridad'	=> $Seguridad,
					'Comprobante' => $comprobanteProductoObject,
					'Emisor' => $emisorObject,
					'Receptor' => $receptorObject,
					'Conceptos' => $conceptosProductoObject,
					'ImpuestosTrasladados' => $impuestosProductoObject,
					'ImpuestosRetenidos' => null
				);
				$servicio="http://74.50.117.161:100/WebServiceCFDI.asmx?WSDL";
				$client = new SoapClient($servicio);
				$respuestaProducto[] = $client->timbrarv1($params);
			}
			
			$data['Seguridad'] = $Seguridad;
			$data['comprobanteProductoObject'] = $comprobanteProductoObject;			
			$data['comprobanteServicioObject'] = $comprobanteServicioObject;		
			$data['receptorObject'] = $receptorObject;
			$data['emisorObject'] = $emisorObject;
			$data['conceptosProductoObject'] = $conceptosProductoObject;
			$data['impuestosProductoObject'] = $impuestosProductoObject;
			$data['conceptosServicioObject'] = $conceptosServicioObject;
			$data['impuestosServicioObject'] = $impuestosServicioObject;
			$data['respuestaWEBSERVICE'] = $respuestaProducto;
			$return['data'] = $data;
			echo json_encode($return['data']);
		}
		
		public function GetMethodPaySAT($methodpay)
		{
			$result='';
			switch ($methodpay)
            {
                case "Efectivo":
                    $result = "01";
                    break;
                case "Cheque":
                    $result = "02";
                    break;
                case "Transferencia electrónica de fondos":
                    $result = "03";
                    break;
                case "Tarjeta de Crédito":
                    $result = "04";
                    break;
                case "Monedero Electrónico":
                    $result = "05";
                    break;
                case "Dinero electrónico":
                    $result = "06";
                    break;
                case "Vales de despensa":
                    $result = "08";
                    break;
                case "Tarjeta de Débito":
                    $result = "28";
                    break;
                case "Tarjeta de Servicio":
                    $result = "29";
                    break;
                default:
                    $result = "99";
                    break;
            }
            return $result;
		}
		
		public function encryptPass($pass)
		{
			$passHash = md5($pass);
			$strlen = strlen($passHash);
			$hashedBytes = array();
			$i = 0 ;
			while ($i < $strlen) 
			{
				$pair = substr($passHash, $i, 2) ;
				$hashedBytes[] = hexdec($pair) ;
				$i = $i + 2 ;
			}
			$chars = array_map("chr", $hashedBytes);
			$bin = join($chars);
			$hex = bin2hex($bin);
			return $hex;
		}
	}
?>