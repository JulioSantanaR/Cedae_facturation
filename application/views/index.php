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
													<select class="selectpicker" data-live-search="true" id="sucursal" data-width="100%" name="selectpicker">
														<?php
															foreach($branches as $branch)
															{ 
															  echo '<option value="'.$branch->cve_sucursal.'">'.$branch->nombre.'</option>';
															}
														?>
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
									<button onclick="add()" type="button" class="add btn btn-blue">Agregar</button><br /><br />
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
													<select class="selectpicker estadocls" data-live-search="true" id="estado" data-width="100%" name="estado">
														<?php
															foreach($states as $state)
															{ 
															  echo '<option value="'.$state->clave.'">'.$state->nombre.'</option>';
															}
														?>
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
													<img src="public/assets/img/logocedae.png" class="img-responsive" style="width: 85px;" alt="">
												</div>
												<div class="col-sm-9">
													<p>
														#958624 <span class="muted"><?php echo date("Y-m-d"); ?></span>
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
																<th class="hidden-480">Producto</th>
																<th class="hidden-480">Cantidad</th>
																<th>Total</th>
															</tr>
														</thead>
														<tbody></tbody>
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
								<div class="productoFactura">
									<div class="well">
										<p class="text-muted">Descargar factura de productos.</p>
										<button type="button" id="descargaXMLProducto" class="btn btn-success">Descargar XML Productos</button>
										<button type="button" id="descargaPDFProducto" class="btn btn-primary">Descargar PDF Productos</button>
										<input type="hidden" id="UUIDProducto"/>
									</div><br />
								</div>
								<div class="servicioFactura">
									<div class="well">
										<p class="text-muted">Descargar factura de servicios.</p>
										<button type="button" id="descargaXMLServicio" class="btn btn-success">Descargar XML Servicios</button>
										<button type="button" id="descargaPDFServicio" class="btn btn-primary">Descargar PDF Servicios</button>
										<input type="hidden" id="UUIDServicio"/>
									</div>
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
<div id="failedTicket" style="display: none;" class="demo-preview-alert">
    <div class="alert alert-success media fade in">
		<strong>Mensaje!</strong> No se puede realizar la facturación ya que la fecha del ticket tiene más de 30 días.
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