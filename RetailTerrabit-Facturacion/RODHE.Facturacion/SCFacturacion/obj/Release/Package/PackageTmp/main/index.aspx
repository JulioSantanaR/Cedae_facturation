<%@ Page Title="" Language="C#" MasterPageFile="~/main/masterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SCFacturacion.main.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHeader" runat="server">
    <link href="<%= ResolveUrl("~/main/assets/plugins/bootstrap-datepicker/bootstrap-datepicker.css")%>" rel="stylesheet">
    <link href="<%= ResolveUrl("~/main/assets/pluginshow-fixeds/bootstrap-validator/bootstrapValidator.min.css")%>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/main/assets/plugins/bootstrap-table/bootstrap-table.min.css")%>" rel="stylesheet" />
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

        #facturacion-tab1 .form-control-feedback {
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
                <div id="facturacion-wz">
                    <!--Nav-->
                    <ul class="wz-nav-off wz-icon-inline">
                        <li class="col-xs-3 bg-purple">
                            <a data-toggle="tab" href="#facturacion-tab1">
                                <span class="icon-wrap icon-wrap-xs bg-trans-dark"><i class="fa fa-ticket"></i></span>
                                <br />
                                Ingresar Ticket
                            </a>
                        </li>
                        <li class="col-xs-3 bg-purple">
                            <a data-toggle="tab" href="#facturacion-tab2">
                                <span class="icon-wrap icon-wrap-xs bg-trans-dark"><i class="fa fa-user"></i></span>
                                <br />
                                Datos Fiscales
                            </a>
                        </li>
                        <li class="col-xs-3 bg-purple">
                            <a data-toggle="tab" href="#facturacion-tab3">
                                <span class="icon-wrap icon-wrap-xs bg-trans-dark"><i class="fa fa-file-text-o"></i></span>
                                <br />
                                Confirmar Datos
                            </a>
                        </li>
                        <li class="col-xs-3 bg-purple">
                            <a data-toggle="tab" href="#facturacion-tab4">
                                <span class="icon-wrap icon-wrap-xs bg-trans-dark"><i class="fa fa-download"></i></span>
                                <br />
                                Descargar Factura
                            </a>
                        </li>
                    </ul>

                    <!--Progress bar-->
                    <div class="progress progress-sm progress-striped active">
                        <div class="progress-bar progress-bar-bluelight"></div>
                    </div>

                    <!--Form-->
                    <div class="form-horizontal mar-top">
                        <div class="panel-body">
                            <div class="tab-content">
                                <!--First tab-->
                                <form id="facturacion-tab1" class="tab-pane" action="javascript:void(0);">
                                    <p>Ingresa los siguientes datos que se encuentran en tu ticket de compra.    <a id="modalTicketHelp" title="Ayuda" style="cursor: help"><i class="fa fa-info-circle" style="color: blue;"></i></a></p>
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
                                                        <input type="text" class="form-control" id="ticket" name="ticket" placeholder="No. Ticket" data-width="40%" maxlength="50">
                                                    </div>
                                                </div>


                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label class="col-lg-3 control-label">RFC</label>
                                                    <div class="col-lg-7">
                                                        <input type="text" style="text-transform: uppercase;" class="form-control" id="rfc" name="rfc" placeholder="RFC" maxlength="15">
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
                                        <!-- Table and button to add -->
                                        <button onclick="add()" type="button" class="add btn btn-blue">Agregar</button><br />
                                        <br />
                                        <table class="table table-bordered" id="myTable">
                                            <thead>
                                                <tr>
                                                    <th>Ticket</th>
                                                    <th>Fecha</th>
                                                    <th>Monto del ticket</th>
                                                    <th></th>
                                                </tr>
                                            </thead>
                                        </table>
                                    </div>
                                </form>

                                <!--Second tab-->
                                <form id="facturacion-tab2" class="tab-pane fade" action="javascript:void(0);">
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
                                                        <input type="text" class="form-control" id="razon" name="razon" placeholder="Razón Social" maxlength="500">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label class="col-lg-3 control-label">Código Postal</label>
                                                    <div class="col-lg-7">
                                                        <input type="text" class="form-control" id="cp" name="cp" placeholder="Código Postal" maxlength="5">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label class="col-lg-3 control-label">Pais</label>
                                                    <div class="col-lg-7">
                                                        <input type="text" class="form-control" id="pais" name="pais" placeholder="Pais" value="México" readonly>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label class="col-lg-3 control-label">Estado</label>
                                                    <div class="col-lg-7">
                                                        <!--===================================================-->
                                                        <select class="selectpicker estadocls" data-live-search="true" runat="server" id="estado" data-width="100%" name="estado">
                                                        </select>
                                                        <!--===================================================-->
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label class="col-lg-3 control-label">Delegación / Municipio</label>
                                                    <div class="col-lg-7">
                                                        <input type="text" class="form-control" id="municipio" name="municipio" placeholder="Delegación / Municipio" maxlength="50">
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
                                                        <input type="text" class="form-control" id="colonia" name="colonia" placeholder="Colonia" maxlength="100">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label class="col-lg-3 control-label">Calle</label>
                                                    <div class="col-lg-7">
                                                        <input type="text" class="form-control" id="calle" name="calle" placeholder="Calle" maxlength="200">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label class="col-lg-3 control-label">No. Externo</label>
                                                    <div class="col-lg-7">
                                                        <input type="text" class="form-control" id="noexterno" name="noexterno" placeholder="No. Externo" maxlength="10">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label class="col-lg-3 control-label">No. Interno</label>
                                                    <div class="col-lg-7">
                                                        <input type="text" class="form-control" id="nointerno" name="nointerno" placeholder="No. Interno" maxlength="10">
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label class="col-lg-3 control-label">Correo</label>
                                                    <div class="col-lg-7">
                                                        <input type="text" class="form-control" id="correo" name="correo" placeholder="Correo" maxlength="100">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-12">
                                                <div class="form-group">
                                                    <div class="col-lg-11">
                                                        <button class="btn btn-blue pull-right" id="btn_guardar">Guardar datos</button>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </form>

                                <!--Third tab-->
                                <form id="facturacion-tab3" class="tab-pane" action="javascript:void(0);">
                                    <div class="portlet light">
                                        <div class="portlet-body">
                                            <div class="invoice">
                                                <div class="row invoice-logo">
                                                    <div class="col-sm-3 invoice-logo-space">
                                                        <img src="<%= ResolveUrl("~/main/assets/img/logocedae.png")%>" class="img-responsive" style="width: 85px;" alt="">
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
                                                                <strong>Estado: </strong>
                                                                <span id="estadoprev">-------------</span>
                                                            </li>
                                                            <li>
                                                                <strong>Municipio: </strong>
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
                                                                <strong>Total:</strong>
                                                                <div id="totalfact"></div>
                                                            </li>
                                                        </ul>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </form>

                                <!--Fourth tab-->
                                <form id="facturacion-tab4" class="tab-pane mar-btm" action="javascript:void(0);">
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
                                <button type="button" class="previous btn btn-blue">Atrás</button>
                                <button type="button" class="next btn btn-blue">Siguiente</button>
                                <button type="button" class="finish btn btn-blue" disabled>Fin</button>
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
        <div class="alert alert-success media fade in">
            <strong>Mensaje!</strong> Por favor verifique los campos.
        </div>
    </div>
    <div id="tableAlertfield" style="display: none;" class="demo-preview-alert">
        <div class="alert alert-success media fade in">
            <strong>Mensaje!</strong> Debes de ingresar al menos un ticket para continuar el proceso de facturación.
        </div>
    </div>
    <div id="ticketRepetido" style="display: none;" class="demo-preview-alert">
        <div class="alert alert-success media fade in">
            <strong>Mensaje!</strong> Este ticket ya ha sido agregado a la tabla. Intenta con otro.
        </div>
    </div>
    <div id="ticketEncontrado" style="display: none;" class="demo-preview-alert">
        <div class="alert alert-success media fade in">
            <strong>Mensaje!</strong> Ticket encontrado, se agregó correctamente.
        </div>
    </div>
    <div id="ticketNoEncontrado" style="display: none;" class="demo-preview-alert">
        <div class="alert alert-success media fade in">
            <strong>Mensaje!</strong> Este ticket no fue encontrado. Intenta con otro.
        </div>
    </div>
    <!--===================================================-->
    <!-- End Alert -->

    <div class="media" id="modalok" style="display: none;">
        <div class="media-body">
            [Texto]
        </div>
    </div>
    <div id="preparing-file-modal" title="Preparing report..." style="display: none;">
        We are preparing your report, please wait...
 
    <div class="ui-progressbar-value ui-corner-left ui-corner-right" style="width: 100%; height: 22px; margin-top: 20px;"></div>
    </div>

    <div id="error-modal" title="Error" style="display: none;">
        There was a problem generating your report, please try again.
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceScript" runat="server">
    <script src="<%= ResolveUrl("~/main/assets/plugins/bootstrap-wizard/jquery.bootstrap.wizard.min.js")%>"></script>
    <script src="<%= ResolveUrl("~/main/assets/plugins/chosen/chosen.jquery.min.js")%>"></script>
    <script src="<%= ResolveUrl("~/main/assets/plugins/bootstrap-datepicker/bootstrap-datepicker.js")%>"></script>
    <script src="<%= ResolveUrl("~/main/assets/js/ValidationForm.js")%>"></script>
    <script src="<%= ResolveUrl("~/main/assets/plugins/bootstrap-table/bootstrap-table.min.js")%>"></script>
    <script src="<%= ResolveUrl("~/main/assets/js/jQueryFile.js")%>"></script>
    <script>

        $(document).ready(function () {

            var folio = null;
            $('#dateRangePicker')
                           .datepicker({
                               language: "es"
                               , format: 'yyyy-mm-dd'
                               , autoclose: true
                               , startDate: '2010-01-01',
                               endDate: '2020-12-31'
                           }).on('changeDate', function (e) {
                               // Revalidate the date field
                               $('#facturacion-tab1').bootstrapValidator('revalidateField', 'fechatkc');
                           });;
            // WIZARD
            // =================================================================

            $('#facturacion-wz').bootstrapWizard({
                tabClass: 'wz-classic',
                nextSelector: '.next',
                previousSelector: '.previous',
                onTabClick: function (tab, navigation, index) {
                    return false;
                },
                onInit: function () {
                    $('#facturacion-wz').find('.finish').hide().prop('disabled', true);
                },
                onNext: function (tab, navigation, index) {
                    var validatorObj = $('#facturacion-tab' + index).data('bootstrapValidator');
                    tabsbool = false;
                    validarCOnusltas = false;
                    messagebool = false;
                    if (index == 3) {
                        tabsbool = true;
                    }
                    else {
                        //Revisamos si la tabla tiene al menos un ticket.
                        var tamanoTable = $('#myTable tbody').children().length;
                        if (tamanoTable == 0) {
                            alertFieldTable();
                        }
                        else {
                            tabsbool = true;
                            //Tickets agregados a la tabla
                            var table = $("#myTable tbody");
                            var ticketsTodos = new Array();
                            table.find('tr').each(function (i) {
                                var $tds = $(this).find('td'),
                                numberticket = $tds.eq(0).text();
                                ticketsTodos.push(numberticket);
                            });
                        }
                    }

                    if (tabsbool) {
                        $('#facturacion-tab' + (index + 1)).find("input[type=text], textarea").val("");
                        switch (index) {
                            case 1:
                                var ticketsParameter = ticketsTodos + "";
                                parameters = {
                                    rfc: $("#rfc").val(), tickets: ticketsParameter
                                };
                                newAjaxAsync('<%= ResolveUrl("~/main/index.aspx/GetTicket") %>', parameters, textChange, modalText, 1, 'facturacion-wz');
                                break;
                            case 2:
                                messagebool = true;
                                SaveClientData(2);
                                $("#rfcprev").text($.trim($("#rfc2").val()));
                                $("#razonprev").text($.trim($("#razon").val()));
                                $("#paisprev").text($.trim($("#pais").val()));
                                $("#estadoprev").text($.trim($("#<%=estado.ClientID%> option:selected").text()));
                                $("#municipioprev").text($.trim($("#municipio").val()));
                                $("#coloniaprev").text($.trim($("#colonia").val()));
                                $("#calleprev").text($.trim($("#calle").val()));
                                $("#cpprev").text($.trim($("#cp").val()));
                                $("#noexternoprev").text($.trim($("#noexterno").val()));
                                $("#nointernoprev").text($.trim($("#nointerno").val()));
                                $("#correoprev").text($.trim($("#correo").val()));
                                validarCOnusltas = true;
                                break;
                            case 3:
                                messagebool = true;
                                parameters = {
                                    rfc: $.trim($("#rfc2").val())
                                    , razon: $.trim($("#razon").val())
                                    , pais: "MX"
                                    , estado: $.trim($("#<%=estado.ClientID%> option:selected").val())
                                    , municipio: $.trim($("#municipio").val())
                                    , colonia: $.trim($("#colonia").val())
                                    , calle: $.trim($("#calle").val())
                                    , cp: $.trim($("#cp").val())
                                    , noexterno: $.trim($("#noexterno").val())
                                    , nointerno: $.trim($("#nointerno").val())
                                    , correo: $.trim($("#correo").val())
                                    , folio: $.trim(folio)
                                    , sucursal: $("#<%=sucursal.ClientID%> option:selected").val()
                                };
                                newAjaxAsync('<%= ResolveUrl("~/main/index.aspx/Facturar") %>', parameters, facturado, modalText, 3, 'facturacion-wz');
                                break;
                            default:

                        }
                    }
                    else if (messagebool) {
                        alertFields();
                    }
                    return false;
                },
                onTabShow: function (tab, navigation, index) {

                    var $total = navigation.find('li').length;
                    var $current = index + 1;
                    var $percent = ($current / $total) * 100;
                    var wdt = 100 / $total;
                    var lft = wdt * index;
                    $('#facturacion-wz').find('.progress-bar').css({ width: $percent + '%' });

                    if ($current >= $total) {
                        $('#facturacion-wz').find('.next').hide();
                        $('#facturacion-wz').find('.previous').hide();
                        $('#facturacion-wz').find('.finish').show();
                        $('#facturacion-wz').find('.finish').prop('disabled', false);
                    } else {
                        $('#facturacion-wz').find('.next').show();
                        $('#facturacion-wz').find('.finish').hide().prop('disabled', true);
                    }
                }
            });


            $($('#facturacion-wz').find('.finish')).click(function () {
                location.reload();
            });

            $("#btn_guardar").click(function () {
                SaveClientData(0);
            });

            function SaveClientData(val) {
                var validatorObj = $('#facturacion-tab2').data('bootstrapValidator');
                validatorObj.validate();
                if (validatorObj.isValid()) {
                    parameters = {
                        rfc: $("#rfc2").val()
                        , razon: $("#razon").val()
                        , pais: $("#pais").val()
                        , estado: $("#<%=estado.ClientID%> option:selected").val()
                        , municipio: $("#municipio").val()
                        , colonia: $("#colonia").val()
                        , calle: $("#calle").val()
                        , cp: $("#cp").val()
                        , noexterno: $("#noexterno").val()
                        , nointerno: $("#nointerno").val()
                        , correo: $("#correo").val()
                    };
                    newAjaxAsync('<%= ResolveUrl("~/main/index.aspx/AddClient") %>', parameters, modalTextOK, modalText, val, 'facturacion-wz')
                }
                else {
                    alertFields();
                }
            }

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
                    $("#pais").val($.trim("México"));
                    if (obj.Object[0].client.estado == null)
                        $('#<%=estado.ClientID%>').selectpicker('val', "AGS");
                    else
                        $('#<%=estado.ClientID%>').selectpicker('val', obj.Object[0].client.estado);
                    $("#municipio").val($.trim(obj.Object[0].client.municipio));
                    $("#colonia").val($.trim(obj.Object[0].client.colonia));
                    $("#calle").val($.trim(obj.Object[0].client.calle));
                    $("#cp").val($.trim(obj.Object[0].client.cp));
                    $("#noexterno").val($.trim(obj.Object[0].client.noexterno));
                    $("#nointerno").val($.trim(obj.Object[0].client.nointerno));
                    $("#correo").val($.trim(obj.Object[0].client.email));
                    $("#tbl_items tbody").html(obj.Body);

                    totalsum = 0;
                    for (var i = 0; i < obj.Object[0].ticket.length; i++) {
                        totalsum += obj.Object[0].ticket[i].total;
                    }

                    $("#totalfact").html("$" + ($.trim(totalsum.toFixed(2))));
                    folio = obj.ID;
                    return true;
                }
                catch (e) {
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

            function modalTextOK(obj) {
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

            $("#modalTicketHelp").click(function () {
                bootbox.dialog({
                    title: "Datos de Ticket",
                    message: '<center><img src="<%= ResolveUrl("~/main/assets/img/ticket.png")%>" width="65%"/></center>'
                });
            });

        });

        function facturado(obj) {
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
                $.fileDownload('<%= ResolveUrl("~/main/Download.aspx") %>',
                {
                    httpMethod: "GET",
                    data: {
                        ext: ext,
                        tipo: tipo,
                        folio: folio
                    }
                });
            }
            catch (e) {
                alert(e);
            }
        }

        //Agregar ticket a la tabla de previsualización con la finalidad de tener multitickets
        function add() {
            var date = document.getElementById("fechatkc").value;
            var Noticket = $.trim(document.getElementById("ticket").value);
            var montoTicket = document.getElementById("monto").value;
            var tienda = $("#<%=sucursal.ClientID%> option:selected").val();
            var validatorObj = $('#facturacion-tab1').data('bootstrapValidator');
            var ticketNuevo = true;



            //Determinar si el ticket ya existe en la tabla de previsualización o no
            $("#myTable tbody tr").each(function (e, f, d) {
                if ($(f).find("td")[0].innerText == $.trim(Noticket)) {
                    ticketNuevo = false;
                    alertTicketRepetido();
                }
            });

            //Validar los campos obligatorios
            tabsbool = false;
            validatorObj.validate();
            tabsbool = validatorObj.isValid();

            //Campos validados correctamente
            if (tabsbool) {
                if (ticketNuevo) {
                    parameters = { numberTicket: Noticket, store: tienda, dateTicket: date, totalTicket: montoTicket };
                    obj = null;
                    val = false;
                    $.ajax({
                        type: "POST",
                        url: '<%= ResolveUrl("~/main/index.aspx/GetInformationTicket") %>',
                        data: JSON.stringify(parameters),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: true,
                        error: function (request, status, error) {
                            alert("Error...");
                        },
                        success: function (msg) {
                            obj = msg.d;
                            if (msg.d.Status == 1) {
                                alertTicketEncontrado();
                                $("#myTable").append(msg.d.Body);
                                $("#rfc").attr('disabled', 'disabled');
                                $("#fechatkc").val('');
                                $("#ticket").val('');
                                $("#monto").val('');
                            }
                            else {
                                alertTicketNoEncontrado();
                            }
                        }
                    });
                }
            }
        }

        //Quitar elemento de la tabla
        function remove(t) {
            var td = t.parentNode;
            var tr = td.parentNode;
            var table = tr.parentNode;
            table.removeChild(tr);

            ticketexistintable = false;

            $("#myTable tbody tr").each(function (e, f, d) {
                ticketexistintable = true;
            });

            if (!ticketexistintable)
                $("#rfc").removeAttr('disabled');

        }

        //Mensajes de alerta...
        function alertFieldTable() {
            alertContent = $('#tableAlertfield').find('.alert').html();
            contentHTML = alertContent;
            $.niftyNoty({
                type: "danger",
                container: 'floating',
                html: contentHTML,
                timer: true ? 3000 : 0
            });
        }
        function alertTicketRepetido() {
            alertContent = $('#ticketRepetido').find('.alert').html();
            contentHTML = alertContent;
            $.niftyNoty({
                type: "info",
                container: 'floating',
                html: contentHTML,
                timer: true ? 3000 : 0
            });
        }
        function alertTicketEncontrado() {
            alertContent = $('#ticketEncontrado').find('.alert').html();
            contentHTML = alertContent;
            $.niftyNoty({
                type: "success",
                container: 'floating',
                html: contentHTML,
                timer: true ? 3000 : 0
            });
        }
        function alertTicketNoEncontrado() {
            alertContent = $('#ticketNoEncontrado').find('.alert').html();
            contentHTML = alertContent;
            $.niftyNoty({
                type: "danger",
                container: 'floating',
                html: contentHTML,
                timer: true ? 3000 : 0
            });
        }
    </script>
</asp:Content>
