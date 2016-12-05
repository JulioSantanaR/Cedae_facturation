<?php
	class Client extends CI_Controller
	{
		public function __construct()
		{
			parent::__construct();
			$this->load->database();
		}
		
		public function GetTicketClient()
		{			
			$rfc = $this->input->post('rfc');
			$tickets = $this->input->post('tickets');
			$clientModel = array (
			   'razonsocial' => '',
			   'pais' => '',
			   'estado' => '',
			   'municipio' => '',
			   'colonia' => '',
			   'calle' => '',
			   'noexterno' => '',
			   'nointerno' => '',
			   'cp' => '',
			   'email' => ''
			);
			$clientObj = (object) $clientModel;
			try
			{
				$listClient = $this->ClientModel->GetClient($rfc);
				$listTickets = $this->TicketModel->GetTickets($tickets);
				//Recorremos la lista de productos encontrados en el Ticket para mostrarlos en la vista previa, antes de facturar
				$table='';
				for($i=0; $i < count($listTickets); $i++)
				{
					$table .= 
					'<tr>
						<td>'.$listTickets[$i]->nombre.'</td>
						<td>'.$listTickets[$i]->cantidad.'</td>
						<td>'.$listTickets[$i]->total.'</td>
					</tr>';
				}
				$data['Body'] = $table;
				$data['ID'] = $tickets;
				$data['ticket'] = $listTickets;
				$data['status'] = true;
				//Revisamos si se encontró el cliente en la BD de otro modo se devuelve el objeto vacio
				if(count($listClient) > 0)
				{
					$clientObj->razonsocial = $listClient[0]->razonsocial;
					$clientObj->pais = $listClient[0]->pais;
					$clientObj->estado = $listClient[0]->estado;
					$clientObj->municipio = $listClient[0]->municipio;
					$clientObj->colonia = $listClient[0]->colonia;
					$clientObj->calle = $listClient[0]->calle;
					$clientObj->noexterno = $listClient[0]->noexterno;
					$clientObj->nointerno = $listClient[0]->nointerno;
					$clientObj->cp = $listClient[0]->cp;
					$clientObj->email = $listClient[0]->email;
					$data['client'] = $clientObj;
				}
				else
				{
					$data['client'] = $clientObj;
				}
			}
			catch (Exception $e) 
			{
				$data['status'] = "Exception";
				$data['message'] = $e->getMessage();				
			}
			$return['data'] = $data;
			echo json_encode($return['data']);
		}
		
		public function AddClient()
		{
			$rfcin = $this->input->post('rfc');
			$razonsocialin = $this->input->post('razon');
			$paisin = $this->input->post('pais');
			$estadoin = $this->input->post('estado');
			$municipioin = $this->input->post('municipio');
			$coloniain = $this->input->post('colonia');
			$callein = $this->input->post('calle');
			$cpin = $this->input->post('cp');
			$noexternoin = $this->input->post('noexterno');
			$nointernoin = $this->input->post('nointerno');
			$correoin = $this->input->post('correo');
			try
			{
				$this->ClientModel->AddClient($rfcin,$razonsocialin,$paisin,$estadoin,$municipioin,$coloniain,$callein,$cpin,$noexternoin,$nointernoin,$cpin,$correoin);
				$data['Message'] = "Se guardaron correctamente sus datos";
				$data['status'] = true;
			}
			catch (Exception $e) 
			{
				$data['status'] = "Exception";
				$data['Message'] = $e->getMessage();				
			}
			$return['data'] = $data;
			echo json_encode($return['data']);
		}
	}
?>