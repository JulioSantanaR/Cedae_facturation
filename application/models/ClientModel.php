<?php
	class ClientModel extends CI_Model
	{
		public function __construct()
		{
			parent::__construct();
		}

		function GetClient($rfc)
		{
			$sp = "CALL sps_clientes (?)";
			$params = array (
				'PARAM_1' => $rfc
			);
			$query = $this->db->query($sp,$params);
			$res = $query->result();
			return $res;
		}
		
		function AddClient($rfcin,$razonsocialin,$paisin,$estadoin,$municipioin,$coloniain,$callein,$cpin,$noexternoin,$nointernoin,$cpin,$correoin)
		{
			$sp = "CALL sp_clientes (?,?,?,?,?,?,?,?,?,?,?)";
			$params = array (
				'PARAM_1' => $rfcin,
				'PARAM_2' => $razonsocialin,
				'PARAM_3' => $paisin,
				'PARAM_4' => $estadoin,
				'PARAM_5' => $municipioin,
				'PARAM_6' => $coloniain,
				'PARAM_7' => $callein,
				'PARAM_8' => $noexternoin,
				'PARAM_9' => $cpin,
				'PARAM_10' => $correoin,
				'PARAM_11' => $nointernoin
			);
			$query = $this->db->query($sp,$params);
			if($query)
			{
				$res = 1;
			}
			else
			{
				$res = 0;
			}
			return $res;
		}
	}
?>