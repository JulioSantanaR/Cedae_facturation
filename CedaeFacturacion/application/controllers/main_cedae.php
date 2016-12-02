<?php
	class Main_Cedae extends CI_Controller
	{
		public function __construct()
		{
			parent::__construct();
			$this->load->database();
		}
		
		public function index()
		{
			$indexValues['branches'] = $this->BranchModel->getAllBranches();
			$indexValues['states'] = $this->StateModel->getAllStates();
			$data = array('header'=>'header','content'=>'index','scripts'=>'scripts','indexValues'=>$indexValues);
			$this->load->view('main_cedae',$data);
		}
	}
?>