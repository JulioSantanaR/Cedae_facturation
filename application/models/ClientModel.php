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
	}
?>