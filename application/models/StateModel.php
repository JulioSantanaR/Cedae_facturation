<?php
	class StateModel extends CI_Model
	{
		public function __construct()
		{
			parent::__construct();
		}

		function getAllStates()
		{
			$query = $this->db->query('CALL sps_estado()');
			mysqli_next_result($this->db->conn_id);
			return $query->result();
		}
	}
?>