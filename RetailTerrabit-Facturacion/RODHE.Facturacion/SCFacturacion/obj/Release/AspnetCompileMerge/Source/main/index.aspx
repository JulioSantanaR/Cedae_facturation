<%@ Page Title="" Language="C#" MasterPageFile="~/main/masterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SCFacturacion.main.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHeader" runat="server">
    <link href="assets/plugins/bootstrap-datepicker/bootstrap-datepicker.css" rel="stylesheet">
    <link href="assets/plugins/bootstrap-validator/bootstrapValidator.min.css" rel="stylesheet" />
    <link href="assets/plugins/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" />
    <style>
        .invoice table {
            margin: 30px 0 30px 0;
        }

        .invoice .invoice-logo {
            margin-bottom: 20px;
        }

            .invoice .invoice-logo p {
                padding: 5px 0;
                font-size: 26px;
                line-height: 28px;
                text-align: right;
            }

                .invoice .invoice-logo p span {
                    display: block;
                    font-size: 14px;
                }

        .invoice .invoice-logo-space {
            margin-bottom: 15px;
        }

        .invoice .invoice-payment strong {
            margin-right: 5px;
        }

        .invoice .invoice-block {
            text-align: right;
        }

            .invoice .invoice-block .amounts {
                margin-top: 20px;
                font-size: 14px;
            }

        #sta-cls-tab1 .form-control-feedback {
            top: 0;
            right: -15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceBody" runat="server">


    <div class="row">
        <div class="col-lg-12">
            <div class="panel">

                <!-- Wizard -->
                <!--===================================================-->
                <div id="sta-cls-wz">
                    <!--Nav-->
                    <ul class="wz-nav-off wz-icon-inline">
                        <li class="col-xs-3 bg-purple">
                            <a data-toggle="tab" href="#sta-cls-tab1">
                                <span class="icon-wrap icon-wrap-xs bg-trans-dark"><i class="fa fa-ticket"></i></span>Ingresar Ticket
                            </a>
                        </li>
                        <li class="col-xs-3 bg-purple">
                            <a data-toggle="tab" href="#sta-cls-tab2">
                                <span class="icon-wrap icon-wrap-xs bg-trans-dark"><i class="fa fa-user"></i></span>Datos Fiscales
                            </a>
                        </li>
                        <li class="col-xs-3 bg-purple">
                            <a data-toggle="tab" href="#sta-cls-tab3">
                                <span class="icon-wrap icon-wrap-xs bg-trans-dark"><i class="fa fa-file-text-o"></i></span>Confirmar Datos
                            </a>
                        </li>
                        <li class="col-xs-3 bg-purple">
                            <a data-toggle="tab" href="#sta-cls-tab4">
                                <span class="icon-wrap icon-wrap-xs bg-trans-dark"><i class="fa fa-download"></i></span>Descargar Factura
                            </a>
                        </li>
                    </ul>

                    <!--Progress bar-->
                    <div class="progress progress-sm progress-striped active">
                        <div class="progress-bar progress-bar-pink"></div>
                    </div>

                    <!--Form-->
                    <div class="form-horizontal mar-top">
                        <div class="panel-body">
                            <div class="tab-content">
                                <!--First tab-->
                                <form id="sta-cls-tab1" class="tab-pane">
                                    <p>Ingresa los siguientes datos que se encuentran en tu ticket de compra.</p>
                                    <hr>
                                    <div class="well">
                                        <div class="row">
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label class="col-lg-3 control-label">Sucursal</label>
                                                    <div class="col-lg-7">
                                                        <!--===================================================-->
                                                        <select class="selectpicker" data-live-search="true" runat="server" id="sucursal" data-width="100%" name="selectpicker">
                                                        </select>
                                                        <!--===================================================-->
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label class="col-lg-3 control-label">Fecha</label>
                                                    <div class="col-lg-7 date">
                                                        <div class="input-group input-append date" id="dateRangePicker">
                                                            <input type="text" class="form-control" name="fechatkc" id="fechatkc" />
                                                            <span class="input-group-addon add-on"><span class="fa fa-calendar fa-lg"></span></span>
                                                        </div>
                                                    </div>
                                                </div>


                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label class="col-lg-3 control-label">Ticket</label>
                                                    <div class="col-lg-7">
                                                        <input type="text" class="form-control" id="ticket" name="ticket" placeholder="No. Ticket" data-width="40%">
                                                    </div>
                                                </div>


                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label class="col-lg-3 control-label">RFC</label>
                                                    <div class="col-lg-7">
                                                        <input type="text" style="text-transform: uppercase;" class="form-control" id="rfc" name="rfc" placeholder="RFC">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label class="col-lg-3 control-label">Monto Pagado</label>
                                                    <div class="col-lg-7">
                                                        <input type="text" class="form-control" id="monto" name="monto" placeholder="Monto Pagado">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                </div>
                                            </div>
                                        </div>
                                        <!--   <div class="row">
                                             <table id="tablaex" data-search="true"
								                               data-show-refresh="true"
								                               data-show-toggle="true"
								                               data-show-columns="true"
								                               data-sort-name="id"
								                               data-page-list="[5, 10, 20]"
								                               data-page-size="10"
								                               data-pagination="true" 
								                               data-show-pagination-switch="true"
								                               data-show-export="true">
                                                 <thead>
                                                     <tr>
                                                         <th data-field="cve_cliente" data-sortable="true" data-formatter="invoiceFormatter">cve_cliente</th>
                                                         <th data-field="razonsocial" data-sortable="true" data-formatter="invoiceFormatter">Razon social</th>
                                                         <th data-field="rfc" data-sortable="true" data-formatter="invoiceFormatter">RFC</th>                                                      

                                                     </tr>
                                                 </thead>
                                                 <tbody></tbody>
                                                                                           </table>
                                             
                                             </div> -->
                                    </div>
                                </form>

                                <!--Second tab-->
                                <form id="sta-cls-tab2" class="tab-pane fade">
                                    <div class="well">
                                        <p>Ingresa tus datos fiscales para generar la factura electrónica, al finalizar haz clic en el botón Siguiente.</p>
                                        <hr>
                                        <div class="row">
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label class="col-lg-3 control-label">RFC</label>
                                                    <div class="col-lg-7">
                                                        <input type="text" class="form-control" id="rfc2" name="rfc2" placeholder="RFC" disabled>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label class="col-lg-3 control-label">Razón Social</label>
                                                    <div class="col-lg-7">
                                                        <input type="text" class="form-control" id="razon" name="razon" placeholder="Razón Social">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label class="col-lg-3 control-label">Código Postal</label>
                                                    <div class="col-lg-7">
                                                        <input type="text" class="form-control" id="cp" name="cp" placeholder="Código Postal">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label class="col-lg-3 control-label">Estado</label>
                                                    <div class="col-lg-7">
                                                        <input type="text" class="form-control" id="pais" name="pais" placeholder="Pais">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label class="col-lg-3 control-label">Estado</label>
                                                    <div class="col-lg-7">
                                                        <input type="text" class="form-control" id="estado" name="estado" placeholder="Estado">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label class="col-lg-3 control-label">Delegación / Municipio</label>
                                                    <div class="col-lg-7">
                                                        <input type="text" class="form-control" id="municipio" name="municipio" placeholder="Delegación / Municipio">
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="col-sm-6">
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label class="col-lg-3 control-label">Colonia</label>
                                                    <div class="col-lg-7">
                                                        <input type="text" class="form-control" id="colonia" name="colonia" placeholder="Colonia">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label class="col-lg-3 control-label">Calle</label>
                                                    <div class="col-lg-7">
                                                        <input type="text" class="form-control" id="calle" name="calle" placeholder="Calle">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label class="col-lg-3 control-label">No. Externo</label>
                                                    <div class="col-lg-7">
                                                        <input type="text" class="form-control" id="noexterno" name="noexterno" placeholder="No. Externo">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label class="col-lg-3 control-label">No. Interno</label>
                                                    <div class="col-lg-7">
                                                        <input type="text" class="form-control" id="nointerno" name="nointerno" placeholder="No. Interno">
                                                    </div>
                                                </div>
                                            </div>                                            
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label class="col-lg-3 control-label">Correo</label>
                                                    <div class="col-lg-7">
                                                        <input type="text" class="form-control" id="correo" name="correo" placeholder="Correo">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-12">
                                                <div class="form-group">
                                                    <div class="col-lg-11">
                                                        <button class="btn btn-purple pull-right" id="btn_guardar">Guardar datos</button>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </form>

                                <!--Third tab-->
                                <form id="sta-cls-tab3" class="tab-pane">
                                    <div class="portlet light">
                                        <div class="portlet-body">
                                            <div class="invoice">
                                                <div class="row invoice-logo">
                                                    <div class="col-sm-3 invoice-logo-space">
                                                        <img src="assets/img/logo.png" class="img-responsive" style="width: 85px;" alt="">
                                                    </div>
                                                    <div class="col-sm-9">
                                                        <p>
                                                            #958624 <span class="muted"><%=DateTime.Now.ToString("dd MMMM yyyy") %></span>
                                                        </p>
                                                    </div>
                                                </div>
                                                <hr>
                                                <div class="row">
                                                    <div class="col-sm-4">
                                                        <h3>Santa Clara:</h3>
                                                        <ul class="list-unstyled">
                                                            <li>
                                                                <strong>RFC: </strong>
                                                                <span>SCM850529GZ7</span>
                                                            </li>
                                                            <li>
                                                                <strong>Razón Social: </strong>
                                                                <span>Santa Clara Mercantil de Pachuca S. de R.L de C.V.</span>
                                                            </li>
                                                            <li>
                                                                <strong>Direccion: </strong>
                                                                <span>Calzada de Cuesco S/N Col. Cuesco ,Pachuca, Hidalgo</span>
                                                            </li>
                                                            <li>
                                                                <strong>CP: </strong>
                                                                <span>42080</span>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <h3>Cliente:</h3>
                                                        <ul class="list-unstyled">
                                                            <li>
                                                                <strong>Nombre: </strong>
                                                                <span id="razonprev"></span>
                                                            </li>
                                                            <li>
                                                                <strong>RFC: </strong>
                                                                <span id="rfcprev">-------------</span>
                                                            </li>
                                                            <li>
                                                                <strong>País: </strong>
                                                                <span id="paisprev">-------------</span>
                                                            </li>
                                                            <li>
                                                                <strong> Estado: </strong>
                                                                <span id="estadoprev">-------------</span>
                                                            </li>
                                                            <li>
                                                                <strong> Municipio: </strong>
                                                                <span id="municipioprev">-------------</span>
                                                            </li>
                                                            <li>
                                                                <strong>Colonia: </strong>
                                                                <span id="coloniaprev">-------------</span>
                                                            </li>
                                                            <li>
                                                                <strong>Calle: </strong>
                                                                <span id="calleprev">-------------</span>
                                                            </li>
                                                            
                                                        </ul>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <h3>
                                                            <br>
                                                        </h3>
                                                        <ul class="list-unstyled">
                                                            <li>
                                                                <strong>No. Externo: </strong>
                                                                <span id="noexternoprev">-------------</span>
                                                            </li>
                                                            <li>
                                                                <strong>No. Interno: </strong>
                                                                <span id="nointernoprev">-------------</span>
                                                            </li>
                                                            <li>
                                                                <strong>CP: </strong>
                                                                <span id="cpprev">-------------</span>
                                                            </li>
                                                            <li>
                                                                <strong>Email: </strong>
                                                                <span id="correoprev">-------------</span>
                                                            </li>
                                                            
                                                        </ul>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class=" table-responsive col-sm-12">
                                                        <table id="tbl_items" class="table table-striped table-hover">
                                                            <thead>
                                                                <tr>
                                                                    <th class="hidden-480">Producto
                                                                    </th>
                                                                    <th class="hidden-480">Cantidad
                                                                    </th>                                                                 
                                                                    <th>Total
                                                                    </th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-4">
                                                    </div>
                                                    <div class="col-sm-8 invoice-block">
                                                        <ul class="list-unstyled amounts">                                                           
                                                            <li>
                                                                <strong>Total:</strong> <div id="totalfact"></div>
                                                            </li>
                                                        </ul>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </form>

                                <!--Fourth tab-->
                                <form id="sta-cls-tab4" class="tab-pane mar-btm">
                                    <h4>Gracias por facturar con nosotros</h4>
                                    <div class="well">
                                        <p class="text-muted">En breve recibira un correo con su factura  </p>
                                    </div>
                                </form>
                            </div>
                        </div>


                        <!--Footer button-->
                        <div class="panel-footer text-right">
                            <div class="box-inline">
                                <button type="button" class="previous btn btn-purple">Atrás</button>
                                <button type="button" class="next btn btn-purple">Siguiente</button>
                                <button type="button" class="finish btn btn-pink" disabled>Fin</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!--===================================================-->
                <!-- End Classic Form Wizard -->
            </div>
        </div>
    </div>
    <!-- Alert -->
    <!--===================================================-->
    <div id="alertfield" style="display: none;" class="demo-preview-alert">
        <!-- Alert layout example -->
        <div class="alert alert-success media fade in">
            <strong>Mensaje!</strong> Por favor verifique los campos.
        </div>
        <!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ -->
    </div>
    <!--===================================================-->
    <!-- End Alert -->

    <div class="media" id="modalok" style="display:none;">        
        <div class="media-body">            
            [Texto]
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceScript" runat="server">
    <script src="assets/plugins/bootstrap-wizard/jquery.bootstrap.wizard.min.js"></script>
    <script src="assets/plugins/chosen/chosen.jquery.min.js"></script>
    <script src="assets/plugins/bootstrap-datepicker/bootstrap-datepicker.js"></script>
    <script src="assets/js/ValidationForm.js"></script>
    <script src="assets/plugins/bootstrap-table/bootstrap-table.min.js"></script>
    <script src="assets/js/ajaxdownloader.js"></script>
    <script>     

        $(document).ready(function () {          

            var folio = null;
            $('#dateRangePicker')
                           .datepicker({
                               language: "es"
                               , format: 'dd/mm/yyyy'
                               , autoclose: true
                               , startDate: '01/01/2010',
                               endDate: '30/12/2020'
                           }).on('changeDate', function (e) {
                               // Revalidate the date field
                               $('#sta-cls-tab1').bootstrapValidator('revalidateField', 'fechatkc');
                           });;

            // WIZARD
            // =================================================================
            $('#sta-cls-wz').bootstrapWizard({
                tabClass: 'wz-classic',
                nextSelector: '.next',
                previousSelector: '.previous',
                onTabClick: function (tab, navigation, index) {
                    return false;
                },
                onInit: function () {
                    $('#sta-cls-wz').find('.finish').hide().prop('disabled', true);
                },
                onNext: function (tab, navigation, index) {

                    var validatorObj = $('#sta-cls-tab' + index).data('bootstrapValidator');
                    tabsbool = false;
                    validarCOnusltas = false;
                    if (index == 3) {
                        tabsbool = true;
                    } else {
                        validatorObj.validate();
                       
                        tabsbool=  validatorObj.isValid()
                    }                    
                    
                    if (tabsbool) {
                        $('#sta-cls-tab' + (index + 1)).find("input[type=text], textarea").val("");
                        switch (index) {
                            case 1:

                                parameters = {
                                    sucursal: $("#<%=sucursal.ClientID%> option:selected").val()
                                    , ticket: $("#ticket").val(), rfc: $("#rfc").val()
                                    , monto: $("#monto").val()
                                    , fecha: $("#fechatkc").val()
                                };                           
                                
                                    validarCOnusltas = newAjaxNoAsync('<%= ResolveUrl("~/main/index.aspx/GetTicket") %>', parameters, textChange, modalText);

                                break;
                            case 2:
                                $("#rfcprev").text($.trim($("#rfc2").val()));
                                $("#razonprev").text($.trim($("#razon").val()));
                                $("#paisprev").text($.trim($("#pais").val()));
                                $("#estadoprev").text($.trim($("#estado").val()));
                                $("#municipioprev").text($.trim($("#municipio").val()));
                                $("#coloniaprev").text($.trim($("#colonia").val()));
                                $("#calleprev").text($.trim($("#calle").val()));
                                $("#cpprev").text($.trim($("#cp").val()));
                                $("#nointernoprev").text($.trim($("#nointerno").val()));
                                $("#noexternoprev").text($.trim($("#noexterno").val()));
                                $("#correoprev").text($.trim($("#correo").val()));
                                validarCOnusltas = true;
                                break;
                            case 3:
                                parameters = {
                                    rfc: $.trim($("#rfc2").val())
                                    , razon: $.trim($("#razon").val())
                                    , pais: $.trim($("#pais").val())
                                    , estado: $.trim($("#estado").val())
                                    , municipio: $.trim($("#municipio").val())
                                    , colonia: $.trim($("#colonia").val())
                                    , calle: $.trim($("#calle").val())
                                    , cp: $.trim($("#cp").val())
                                    , nointerno: $.trim($("#nointerno").val())
                                    , noexterno: $.trim($("#noexterno").val())
                                    , correo: $.trim($("#correo").val())
                                    , folio: $.trim(folio)
                                };

                               validarCOnusltas = newAjaxNoAsync('<%= ResolveUrl("~/main/index.aspx/Facturar") %>', parameters, facturado, modalText);
                                                      
                               
                                break;
                            default:

                        }
                    } else {
                        alertFields();
                    }

                    return validarCOnusltas;

                },
                onTabShow: function (tab, navigation, index) {

                    var $total = navigation.find('li').length;
                    var $current = index + 1;
                    var $percent = ($current / $total) * 100;
                    var wdt = 100 / $total;
                    var lft = wdt * index;
                    $('#sta-cls-wz').find('.progress-bar').css({ width: $percent + '%' });

                    if ($current >= $total) {
                        $('#sta-cls-wz').find('.next').hide();
                        $('#sta-cls-wz').find('.previous').hide();
                        $('#sta-cls-wz').find('.finish').show();
                        $('#sta-cls-wz').find('.finish').prop('disabled', false);
                    } else {
                        $('#sta-cls-wz').find('.next').show();
                        $('#sta-cls-wz').find('.finish').hide().prop('disabled', true);
                    }
                }
            });


            $($('#sta-cls-wz').find('.finish')).click(function () {
                location.reload();
            });

            $("#btn_guardar").click(function () {

                var validatorObj = $('#sta-cls-tab2').data('bootstrapValidator');
                validatorObj.validate();              
                if (validatorObj.isValid()) {
                    parameters = {
                        rfc: $("#rfc2").val()
                        , razon: $("#razon").val()
                        , pais: $("#pais").val()
                        , estado: $("#estado").val()
                        , municipio: $("#municipio").val()
                        , colonia: $("#colonia").val()
                        , calle: $("#calle").val()
                        , cp: $("#cp").val()
                        , nointerno: $("#nointerno").val()
                        , noexterno: $("#noexterno").val()
                        , correo: $("#correo").val()
                    };

                    newAjaxAsync('<%= ResolveUrl("~/main/index.aspx/AddClient") %>', parameters, modalText, modalText)
                } else {
                    alertFields();
                }
                
            });



            function alertFields() {
                alertContent = $('#alertfield').find('.alert').html();
                contentHTML = alertContent;
                $.niftyNoty({
                    type: "danger",
                    container: 'floating',
                    html: contentHTML,
                    timer: true ? 3000 : 0
                });
            }

            function textChange(obj) {
                try {

                    $("#rfc2").val($.trim($("#rfc").val().toUpperCase()));
                    $("#razon").val($.trim(obj.Object[0].client.razonsocial));
                    $("#pais").val($.trim(obj.Object[0].client.pais));
                    $("#estado").val($.trim(obj.Object[0].client.estado));
                    $("#municipio").val($.trim(obj.Object[0].client.municipio));                    
                    $("#colonia").val($.trim(obj.Object[0].client.colonia));
                    $("#calle").val($.trim(obj.Object[0].client.calle));
                    $("#cp").val($.trim(obj.Object[0].client.cp));
                    $("#nointerno").val($.trim(obj.Object[0].client.nointerno));
                    $("#noexterno").val($.trim(obj.Object[0].client.noexterno));
                    $("#correo").val($.trim(obj.Object[0].client.email));
                    $("#totalfact").html($.trim(obj.Object[0].ticket[0].total));
                    
                    $("#tbl_items tbody").html(obj.Body);
                    folio = obj.ID;
                    return true;

                } catch (e) {

                    return false;
                }



            }
            function modalText(obj) {

                textomodal = $('#modalok').html();
                textomodal = textomodal.replace('style="display:none;"', '').replace("[Texto]", obj.Message)
                bootbox.dialog({
                    title: "Mensaje",
                    message: textomodal,
                    buttons: {
                        confirm: {
                            label: "Aceptar"
                        }
                    }
                });

                return false;
            }


          

        });

        function facturado(obj)
        {
            textomodal = $('#modalok').html();
            textomodal = textomodal.replace('style="display:none;"', '').replace("[Texto]", obj.Message)
            bootbox.dialog({
                title: "Mensaje",
                message: textomodal,
                buttons: {
                    confirm: {
                        label: "Aceptar"
                    }
                }
            });
            return true;

        }
        function downloadFac(ext, folio, tipo) {

            try {
             
               
                $.AjaxDownloader({
                    url: '<%= ResolveUrl("~/main/Download.aspx") %>',
                    data: {
                        ext: ext,
                        tipo: tipo,
                        folio: folio
                    }
                });
               
            } catch (e) {
                alert(e);
            }
            
        }


               
    </script>

</asp:Content>
