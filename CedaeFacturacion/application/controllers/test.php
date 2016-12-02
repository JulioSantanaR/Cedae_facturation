<?php
	class Test extends CI_Controller {
		public function index()
		{
			//$this->load->view('name');
			//$this->load->view('directory-name/name');
			$this->load->view('test');
		}
		
		public function hello()
		{
			echo "Esta función dice hola";
		}
	}
?>