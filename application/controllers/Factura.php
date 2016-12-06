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
			//Traer desde BD y cifrar contraseña con md5
			$seguridad = array (
			   '0' => 'test',
			   '1' => 'test123$'
			);
			$seguridadObject = (object) $seguridad;
			
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
				$haveDiscount = 'Descuento producto';
			}
			else
			{
				$haveDiscount = '';
			}
			$formaPagoProducto = rtrim($formaPagoProducto, ',');
			$comprobanteProducto = array (
			   '0' => date("Y-m-d H:i:s"),
			   '1' => '30 días',
			   '2' => $descuentoProducto,
			   '3' => $haveDiscount,
			   '4' => $formaPagoProducto,
			   '5' => '1',
			   '6' => 'MXN',
			   '7' => 'CDMX',
			   '8' => ''
			);
			$comprobanteProductoObject = (object) $comprobanteProducto;
			
			$data['seguridad'] = $seguridadObject;
			$data['comprobanteProductoObject'] = $comprobanteProductoObject;			
			$data['listClient'] = $listClient;
			$data['listTickets'] = $listTickets;
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
	}
?>