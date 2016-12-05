<?php
	class Ticket extends CI_Controller
	{
		public function __construct()
		{
			parent::__construct();
			$this->load->database();
		}
		
		public function GetInformationTicket()
		{			
			$numberTicket = $this->input->post('numberTicket');
			$store = $this->input->post('store');
			$dateTicket = $this->input->post('dateTicket');
			$totalTicket = $this->input->post('totalTicket');
			$rfc = $this->input->post('rfc');
			$listTicket = $this->TicketModel->GetInformationTicket($numberTicket,$store,$dateTicket,$totalTicket);
			try
			{
				//Existe el Ticket
				if(count($listTicket) > 0)
				{
					//No ha sido facturado
					if($listTicket[0]->facturado==NULL || $listTicket[0]->facturado==0)
					{
						//Aún se puede facturar
						if(date('Y-m-d', strtotime('-30 days')) <= $listTicket[0]->fchVta)
						{
							$table = 
							'<tr>
								<td>'.$listTicket[0]->cve_ticket.'</td>
								<td>'.$listTicket[0]->fchVta.'</td>
								<td>'.$listTicket[0]->total.'</td>
								<td><button onclick="remove(this)" type="button" class="btn btn-default" aria-label="Left Align"><span class="fa fa-trash" aria-hidden="true"></span></button></td>
							</tr>';
							$data['status'] = true;
							$data['body'] = $table;
						}
						//Ya no se puede facturar
						else
						{
							$data['status'] = "Failed";
							$data['message'] = "No se puede realizar la facturación ya que la fecha del ticket tiene más de 30 días.";
						}
					}
					//Ya fue facturado
					else
					{
						$listFacturados = $this->TicketModel->GetFacturadosInfo($rfc,$numberTicket);
						if(count($listFacturados) > 0)
						{
							foreach($listFacturados as $item)
							{
								if($item->tipo == "productos")
								{
									$data['status'] = true;
									$data['message'] = "El ticket ya puede ser descargado.";
									$data['BodyProducto'] = $item->UUID;
									$data['IDProducto'] = $item->folio;
								}
								else if($item->tipo == "servicios")
								{
									$data['status'] = true;
									$data['message'] = "El ticket ya puede ser descargado.";
									$data['BodyServicio'] = $item->UUID;
									$data['IDServicio'] = $item->folio;
								}
								else
								{
									$data['status'] = true;
									$data['message'] = "El ticket ya fue facturado.";
								}
							}
						}
						//Se quiere facturar con otro RFC
						else
						{
							//Aún se puede facturar
							if(date('Y-m-d', strtotime('-30 days')) <= $listTicket[0]->fchVta)
							{
								$table = 
								'<tr>
									<td>'.$listTicket[0]->cve_ticket.'</td>
									<td>'.$listTicket[0]->fchVta.'</td>
									<td>'.$listTicket[0]->total.'</td>
									<td><button onclick="remove(this)" type="button" class="btn btn-default" aria-label="Left Align"><span class="fa fa-trash" aria-hidden="true"></span></button></td>
								</tr>';
								$data['status'] = true;
								$data['body'] = $table;
							}
							//Ya no se puede facturar
							else
							{
								$data['status'] = "Failed";
								$data['message'] = "No se puede realizar la facturación ya que la fecha del ticket tiene más de 30 días.";
							}
						}
					}
				}
				//No existe el ticket
				else
				{
					$data['status'] = false;
					$data['message'] = "El ticket no existe. Número: ".$numberTicket." ,Sucursal: ".$store." ,Fecha: ".$dateTicket." ,Total: ".$totalTicket;
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
	}
?>