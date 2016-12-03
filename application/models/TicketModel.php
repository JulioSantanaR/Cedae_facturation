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
			$res = $query->result();
			$query->next_result();
			$query->free_result();
			return $res;
		}
		
		function GetFacturadosInfo($rfc,$numberTicket)
		{
			$sp = "CALL sps_facturados (?,?)";
			$params = array (
				'PARAM_1' => $rfc,
				'PARAM_2' => $numberTicket
			);
			$query = $this->db->query($sp,$params);
			return $query->result();
		}
	}
?>