<?php
	class BranchModel extends CI_Model
	{
		public function __construct()
		{
			parent::__construct();
		}

		function getAllBranches()
		{
			$query = $this->db->query('CALL sps_sucursal()');
			mysqli_next_result($this->db->conn_id);
			return $query->result();
		}
	}
?>