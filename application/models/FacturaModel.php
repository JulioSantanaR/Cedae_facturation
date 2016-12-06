<?php
	class FacturaModel extends CI_Model
	{
		public function __construct()
		{
			parent::__construct();
		}

		function AddTicketFacturado($folioin,$cve_ticketin,$fechafacturain,$UUIDin,$rfcin,$tipoin)
		{
			$sp = "CALL spi_facturados (?,?,?,?,?,?)";
			$params = array (
				'PARAM_1' => $folioin,
				'PARAM_2' => $cve_ticketin,
				'PARAM_3' => $fechafacturain,
				'PARAM_4' => $UUIDin,
				'PARAM_5' => $rfcin,
				'PARAM_6' => $tipoin
			);
			$query = $this->db->query($sp,$params);
			$res = $query->result();
			return $res;
		}
	}
?>