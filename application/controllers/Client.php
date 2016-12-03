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
			$data['status'] = true;
			$data['rfc'] = $rfc;
			$data['tickets'] = $tickets;
			$return['data'] = $data;
			echo json_encode($return['data']);
		}
	}
?>