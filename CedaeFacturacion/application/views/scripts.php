<script src="public/assets/plugins/bootstrap-wizard/jquery.bootstrap.wizard.min.js"></script>
<script src="public/assets/plugins/chosen/chosen.jquery.min.js"></script>
<script src="public/assets/plugins/bootstrap-datepicker/bootstrap-datepicker.js"></script>
<script src="public/assets/js/ValidationForm.js"></script>
<script src="public/assets/plugins/bootstrap-table/bootstrap-table.min.js"></script>
<script src="public/assets/js/jQueryFile.js"></script>
<script>
	var ticketsTodos = null;
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
				return true;
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
						ticketsTodos = new Array();
						table.find('tr').each(function (i) {
							var $tds = $(this).find('td'),
							numberticket = $tds.eq(0).text();
							ticketsTodos.push(numberticket);
						});
                    }
				}

				if (tabsbool)
				{
					$('#facturacion-tab' + (index + 1)).find("input[type=text], textarea").val("");
					switch (index)
					{
						case 1:
							var ticketsParameter = ticketsTodos + "";
							parameters = { rfc: $("#rfc").val(), tickets: ticketsParameter };
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
							var ticketsParameter = ticketsTodos + "";
							parameters = {
								sucursal: $("#<%=sucursal.ClientID%> option:selected").val()
								,rfc: $.trim($("#rfc2").val())
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
                                , tickets: ticketsParameter
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
			onTabShow: function (tab, navigation, index)
            {
				var $total = navigation.find('li').length;
				var $current = index + 1;
				var $percent = ($current / $total) * 100;
				var wdt = 100 / $total;
				var lft = wdt * index;
				$('#facturacion-wz').find('.progress-bar').css({ width: $percent + '%' });
				if ($current >= $total)
				{
					$('#facturacion-wz').find('.next').hide();
					$('#facturacion-wz').find('.previous').hide();
					$('#facturacion-wz').find('.finish').show();
					$('#facturacion-wz').find('.finish').prop('disabled', false);
				}
				else
				{
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

		$("#modalTicketHelp").click(function ()
		{
			bootbox.dialog({
				title: "Datos de Ticket",
				message: '<center><img src="<%= ResolveUrl("~/main/assets/img/TicketCe.jpg")%>" width="95%"/></center>'
			});
		});
	});

	//Agregar ticket a la tabla de previsualización con la finalidad de tener multitickets
	function add()
	{
		var date = document.getElementById("fechatkc").value;
		var Noticket = $.trim(document.getElementById("ticket").value);
		var montoTicket = document.getElementById("monto").value;
		var tienda = $("#sucursal option:selected").val();
		var validatorObj = $('#facturacion-tab1').data('bootstrapValidator');
		var rfcClient = $("#rfc").val();
		var ticketNuevo = true;

		//Determinar si el ticket ya existe en la tabla de previsualización o no
		$("#myTable tbody tr").each(function (e, f, d)
		{
			if ($(f).find("td")[0].innerText == $.trim(Noticket))
			{
				ticketNuevo = false;
				alertTicketRepetido();
			}
		});

		//Validar los campos obligatorios
		tabsbool = false;
		validatorObj.validate();
		tabsbool = validatorObj.isValid();

		//Campos validados correctamente
		if (tabsbool)
		{
			if (ticketNuevo)
			{
				parameters = { numberTicket: Noticket, store: tienda, dateTicket: date, totalTicket: montoTicket, rfc: rfcClient };
				obj = null;
				val = false;
				$.ajax({
					type: "POST",
                    url: '<?php echo base_url("index.php/Ticket/GetInformationTicket"); ?>',
                    data: parameters,
                    ContentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    error: function (request, status, error) {
                        alert("Error...");
                    },
                    success: function (data)
                    {
						obj = data;
						if (obj.status == 1)
                        {
                            if(obj.IDProducto != null && obj.IDServicio == null)
                            {
                                modalTextOKFactura(obj.BodyProducto,"Productos");
                            }
                            else if(obj.IDProducto == null && obj.IDServicio != null)
                            {
								modalTextOKFactura(obj.BodyServicio,"Servicios");
                            }
                            else if(obj.IDProducto != null && obj.IDServicio != null)
                            {
								modalTextOKFacturaDoble(obj.BodyProducto,obj.BodyServicio);
							}
                            else
                            {
                                alertTicketEncontrado();
								$("#myTable").append(obj.body);
                                $("#rfc").attr('disabled', 'disabled');
                                $("#sucursal").prop('disabled', 'disabled');
                                $("#fechatkc").val('');
                                $("#ticket").val('');
                                $("#monto").val('');
							}
                        }
                        else
                        {
							alertTicketNoEncontrado();
                        }
					}
				});
            }
        }
    }

	//Quitar elemento de la tabla
	function remove(t)
	{
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
			$("#sucursal").prop('disabled', false);
	}

	//Se facturó correctamente
	function facturado(obj)
	{
		//Se agrega UUID al input de producto
		if (obj.IDProducto != null)
		{
			$("#UUIDProducto").val(obj.IDProducto.toString());
		}
		else
		{
			$(".productoFactura").hide();
		}
		//Se agrega UUID al input de servicio
		if (obj.IDServicio != null)
		{
			$("#UUIDServicio").val(obj.IDServicio.toString());
		}
		else
		{
			$(".servicioFactura").hide();
		}
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

	//Mensajes de alerta...
	function alertFieldTable()
	{
		alertContent = $('#tableAlertfield').find('.alert').html();
		contentHTML = alertContent;
		$.niftyNoty({
			type: "danger",
			container: 'floating',
			html: contentHTML,
			timer: true ? 3000 : 0
		});
	}        
	function alertTicketRepetido()
	{
		alertContent = $('#ticketRepetido').find('.alert').html();
		contentHTML = alertContent;
		$.niftyNoty({
			type: "info",
			container: 'floating',
			html: contentHTML,
			timer: true ? 3000 : 0
		});
	}
	function alertTicketEncontrado()
	{
		alertContent = $('#ticketEncontrado').find('.alert').html();
		contentHTML = alertContent;
		$.niftyNoty({
			type: "success",
			container: 'floating',
			html: contentHTML,
			timer: true ? 3000 : 0
		});
	}
	function alertTicketNoEncontrado()
	{
		alertContent = $('#ticketNoEncontrado').find('.alert').html();
		contentHTML = alertContent;
		$.niftyNoty({
			type: "danger",
			container: 'floating',
			html: contentHTML,
			timer: true ? 3000 : 0
		});
	}
        
	//Eventos onclick para la descarga de la factura, en archivo XML o PDF según sea el caso
	/***** Factura Producto *****/
	$("#descargaXMLProducto").click(function ()
	{
		downloadFac("xml", $("#UUIDProducto").val());
	});
	$("#descargaPDFProducto").click(function ()
	{
		downloadFac("pdf", $("#UUIDProducto").val());
	});
	/***** Factura Servicio *****/
	$("#descargaXMLServicio").click(function ()
	{
		downloadFac("xml", $("#UUIDServicio").val());
	});
	$("#descargaPDFServicio").click(function ()
	{
		downloadFac("pdf", $("#UUIDServicio").val());
	});

	//Función que realiza la descarga del archivo, dependiendo del formato (XML o PDF)
	function downloadFac(ext, uuid)
	{
		try
		{
			$.fileDownload('<%= ResolveUrl("~/main/Download.aspx") %>',
			{
				httpMethod: "GET",
				data:
				{
					ext: ext,
					uuid: uuid
				}
			});
		}
		catch (e) {
			alert(e);
		}
	}

	//Modal para descargar XML y PDF en caso de que ya exista la factura
	function modalTextOKFactura(uuid,tipoFactura)
	{
		textomodal = $('#modalok').html();
		textomodal = textomodal.replace('style="display:none;"', '').replace("[Texto]", "<button type=\"button\" onclick=\"downloadFac('xml','" + uuid + "');\" id=\"descargaXMLProducto\" class=\"btn btn-success\" \">Descargar XML " + tipoFactura + "</button> <button type=\"button\" onclick=\"downloadFac('pdf','" + uuid + "');\" id=\"descargaPDFProducto\" class=\"btn btn-primary\" \">Descargar PDF " + tipoFactura + "</button>");
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

	//Modal para descargar XML y PDF en caso de que ya exista la factura, además que el ticket haya tenido productos y servicios
	function modalTextOKFacturaDoble(uuidP, uuidS)
	{
		textomodal = $('#modalok').html();
		textomodal = textomodal.replace('style="display:none;"', '').replace("[Texto]", "<button type=\"button\" onclick=\"downloadFac('xml','" + uuidP + "');\" id=\"descargaXMLProducto\" class=\"btn btn-success\" \">Descargar XML Productos</button> <button type=\"button\" onclick=\"downloadFac('pdf','" + uuidP + "');\" id=\"descargaPDFProducto\" class=\"btn btn-primary\" \">Descargar PDF Productos</button> <br><br> <button type=\"button\" onclick=\"downloadFac('xml','" + uuidS + "');\" id=\"descargaXMLServicio\" class=\"btn btn-success\" \">Descargar XML Servicios</button> <button type=\"button\" onclick=\"downloadFac('pdf','" + uuidS + "');\" id=\"descargaPDFServicio\" class=\"btn btn-primary\" \">Descargar PDF Servicios</button> ");
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
</script>