function newAjaxNoAsync(url, parameter, successCallback, errorCallback) {
    obj = null;
    val = false;
    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify(parameters),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        error: function (request, status, error) {
            alert("error");
        },
        success: function (msg) {
            obj = msg.d;
            if (msg.d.Status == 1) {
                if (!successCallback(obj)) {
                    val = false;
                } else {
                    val = true;
                }
            }
            else
                val = errorCallback(obj);

        },
        beforeSend: function () {
            Block();
        },
        complete: function () {
            $.unblockUI();
        }
    });
    return val;
}

function newAjaxAsync(url, parameter, successCallback, errorCallback) {
    obj = null;
    val = false;
    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify(parameters),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        error: function (request, status, error) {
            alert("error");
        },
        success: function (msg) {
            obj = msg.d;
            if (msg.d.Status == 1) {
                if (!successCallback(obj)) {
                    val = false;
                } else {
                    val = true;
                }
            }
            else
                val = errorCallback(obj);

        },
        beforeSend: function () {
            Block();
        },
        complete: function () {
            $.unblockUI();
        }
    });
    return val;
}


$('#sta-cls-tab1')
  .bootstrapValidator({
      framework: 'bootstrap',
      feedbackIcons: {
          valid: 'fa fa-check',
          invalid: 'fa fa-times',
          validating: 'fa fa-refresh'
      },
      fields: {

          ticket: {
              validators: {
                  notEmpty: {
                      message: 'Ingrese el numero de ticket..'
                  }
              }
          },
          fechatkc: {
              validators: {                  
                  notEmpty: {
                      message: 'La fecha es requerida.'
                  },
                  date: {
                      format: 'DD/MM/YYYY',
                      min: '01/01/2010',
                      max: '30/12/2020',
                      message: 'La fecha no es valida'
                  }
              }
          },
          rfc: {
              validators: {
                  callback: {
                      message: 'Ingrese un RFC válido.',
                      callback: function (value, validator, $field) {
                          return rfcregex(value);
                      }
                  }
              }
          },
          monto: {
              validators: {
                  notEmpty: {
                      message: 'El monto no debe de estar vacio.'
                  },
                  numeric: {
                      message: 'Debe de ser numerico.'
                  }
              }
          }
      }
  });



$('#sta-cls-tab2')
    .bootstrapValidator({
        framework: 'bootstrap',
        feedbackIcons: {
            valid: 'fa fa-check',
            invalid: 'fa fa-times',
            validating: 'fa fa-refresh'
        },
        fields: {

            razon: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese su razón social.'
                    }
                }
            },
            cp: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese un Código Postal.'
                    },
                    numeric: {
                        message: 'Ingrese un Código postal válido.'
                    }
                }
            },
            pais: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese un Pais..'
                    },
                }
            },
            estado: {
                validators: {
                    notEmpty: {
                        message: 'El monto no debe de estar vacio.'
                    }
                }
            },
            municipio: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese un municipio..'
                    },
                }
            },
            municipio: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese una colonia..'
                    },
                }
            },
            calle: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese una calle..'
                    },
                }
            },
            colonia: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese una colonia..'
                    },
                }
            },
           
            noexterno: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese una noexterno..'
                    },
                }
            },
            correo: {
                validators: {
                    emailAddress: {
                        message: 'Ingrese una dirección de correo.'
                    },
                    regexp: {
                        regexp: '^[^@\\s]+@([^@\\s]+\\.)+[^@\\s]+$',
                        message: 'Ingrese una dirección de correo válida.'
                    }
                }
            }
        }
    });


function rfcregex(RFC) {
    RFC = $.trim(RFC).toUpperCase();
    if (RFC != "XEXX010101000") {
        var regex = new RegExp(/^([A-Z|a-z|&]{3}\d{2}((0[1-9]|1[012])(0[1-9]|1\d|2[0-9])|(0[13456789]|1[012])(29|30)|(0[13578]|1[02])31)|([02468][048]|[13579][26])0229)(\w{2})([A|a|0-9]{1})$|^([A-Z|a-z]{4}\d{2}((0[1-9]|1[012])(0[1-9]|1\d|2[0-8])|(0[13456789]|1[012])(29|30)|(0[13578]|1[02])31)|([02468][048]|[13579][26])0229)((\w{2})([A|a|0-9]{1})){0,3}$/);
        if (!regex.test(RFC)) {
            return false;
        }
    }
    return true;
}