<?php
	class TicketModel extends CI_Model
	{
		public function __construct()
		{
			parent::__construct();
		}

		function GetInformationTicket($numberTicket,$store,$dataTicket,$totalTicket)
		{
			$sp = "CALL sps_informationTicket (?,?,?,?)";
			$params = array (
				'PARAM_1' => $numberTicket,
				'PARAM_2' => $store,
				'PARAM_3' => $dataTicket,
				'PARAM_4' => $totalTicket
			);
			$query = $this->db->query($sp,$params);
			return $query->result();
		}
	}
?>