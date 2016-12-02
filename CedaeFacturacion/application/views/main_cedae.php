<!DOCTYPE html>
<html lang="es">
<head>
    <title>Facturación</title>
    <meta charset="utf-8">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!--stylesheet-->
	<base href="<?php echo base_url();?>" />
	<base src="<?php echo base_url();?>" />
    <link href="public/assets/plugins/font-google/google.css" rel="stylesheet" />
    <link href="public/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="public/assets/css/rodhe.css" rel="stylesheet" />
    <link href="public/assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" />   
    <link href="public/assets/plugins/bootstrap-select/bootstrap-select.min.css" rel="stylesheet" />
    <link href="public/assets/css/themes/type-a/theme-rodhe.css" rel="stylesheet" /> 
    <link href="public/assets/plugins/blockUI/block.css" rel="stylesheet" />
	<?php $this->load->view($header); ?>
</head>
<body>
    <div id="container" class="effect mainnav-lg">
        <!--navbar-->
        <header id="navbar" style="height: 60px;">
            <div id="navbar-container" style="height: 60px;" class="boxed">
                <!--Brand-->
                <!--================================-->
                <div class="navbar-header" style="height: 60px; background: #355681;">
                    <a href="#" style="height: 60px; background: #355681;" class="navbar-brand">
                        <img src="public/assets/img/logocedae.png" alt="CEDAE" style="height: 60px; float: left;">
                        <div class="brand-title" style="height: 60px;">
                            <span style="height: 60px;" class="brand-text">CEDAE</span>
                        </div>
                    </a>
                </div>
                <!--================================-->
                <!--End Brand-->
                <!--Navbar Dropdown-->
                <!--================================-->
                <div class="navbar-content clearfix">
                </div>
                <!--================================-->
                <!--End Navbar Dropdown-->

            </div>
        </header>
        <!--===================================================-->
        <!--END NAVBAR-->

        <div class="boxed">
            <!--CONTENT CONTAINER-->
            <!--===================================================-->
            <div id="content">
                <!--Page Title-->
                <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
                <div id="page-title">
                    <h1 class="page-header text-overflow"></h1>
                </div>
                <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
                <!--End page title-->

                <!--Page content-->
                <!--===================================================-->
                <div id="page-content">
					<?php $this->load->view($content,$indexValues); ?>
                </div>
                <!--===================================================-->
                <!--End page content-->
            </div>
            <!--===================================================-->
            <!--END CONTENT CONTAINER-->
        </div>

        <!-- FOOTER -->
        <!--===================================================-->
        <br />
        <footer id="footer" style="padding-left: 0px;">
            <div class="hide-fixed pull-right pad-rgt" runat="server" id="version"></div>           
            <p class="pad-lft">&#0169;  <?php echo date("Y"); ?> Centro Dermatológico de Alta Especialidad, consulta nuestro 
                <b><a runat="server" id="avisoPrivacidad" href="#" target="_blank">aviso de privacidad aquí</a></b></p>
        </footer>
        <!--===================================================-->
        <!-- END FOOTER -->
        <!-- SCROLL TOP BUTTON -->
        <!--===================================================-->
        <button id="scroll-top" class="btn"><i class="fa fa-chevron-up"></i></button>
        <!--===================================================-->
    </div>
    <!--===================================================-->
    <!-- END OF CONTAINER -->

    <!--JAVASCRIPT-->
    <!--=================================================-->
    <script src="public/assets/js/jquery-2.1.1.min.js"></script>
    <script src="public/assets/js/bootstrap.min.js"></script>
    <script src="public/assets/plugins/fast-click/fastclick.min.js"></script>
    <script src="public/assets/js/nifty.min.js"></script> 
    <script src="public/assets/plugins/bootstrap-select/bootstrap-select.min.js"></script>
    <script src="public/assets/plugins/bootstrap-validator/bootstrapValidator.min.js"></script>
    <script src="public/assets/plugins/bootbox/bootbox.min.js"></script>
    <script src="public/assets/plugins/blockUI/jquery.blockUI.js"></script>
    <script type="text/javascript">
        function Block() {
            $.blockUI({
                message: 'Espere un momento...',
                css: {
                    border: 'none',
                    padding: '15px',
                    backgroundColor: '#000',
                    '-webkit-border-radius': '10px',
                    '-moz-border-radius': '10px',
                    opacity: .5,
                    color: '#fff'
                }
            });
        }

        function BlockPage() {
            $.blockUI({
                message: 'Por el momento no puede facturar , el portal está en mantenimiento...',
                css: {
                    border: 'none',
                    padding: '15px',
                    backgroundColor: '#000',
                    '-webkit-border-radius': '10px',
                    '-moz-border-radius': '10px',
                    opacity: .5,
                    color: '#fff'
                }
            });
        }
    </script>
	<?php $this->load->view($scripts); ?>
</body>
</html>
