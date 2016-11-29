using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace SCFacturacion.BLL
{
    public class Factura
    {

        public static RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Ticket>> FacturarProcess(string tickets)
        {
            RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Ticket>> list = new RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Ticket>>();
            try
            {
                list.Object = RODHE.Tools.DataTabletoClass.ToClassInstanceCollection<RODHE.Facturacion.OBJ.Ticket>(DAL.Ticket.GetTickets(tickets)).ToList();
                list.Status = RODHE.Facturacion.OBJ.Status.sucess;
            }
            catch (Exception ex)
            {
                list.Status = RODHE.Facturacion.OBJ.Status.error;
                list.Message = "No se logró facturar,intente más tarde." + ex.Message;
            }
            return list;
        }

        public static RODHE.Facturacion.OBJ.Control<List<string>> Facturar(string cliente, string rfc, string razon, string pais, string estado
            , string municipio, string colonia, string calle, string cp, string noexterno, string correo, string tickets)
        {
            RODHE.Facturacion.OBJ.Control<List<string>> result = new RODHE.Facturacion.OBJ.Control<List<string>>();
            result.Object = new List<string>();
            try
            {
                List<RODHE.Facturacion.OBJ.Ticket> listTickets = new List<RODHE.Facturacion.OBJ.Ticket>();
                List<RODHE.Facturacion.OBJ.Client> listClient = new List<RODHE.Facturacion.OBJ.Client>();
                listTickets = RODHE.Tools.DataTabletoClass.ToClassInstanceCollection<RODHE.Facturacion.OBJ.Ticket>(DAL.Ticket.GetTickets(tickets)).ToList();
                listClient = RODHE.Tools.DataTabletoClass.ToClassInstanceCollection<RODHE.Facturacion.OBJ.Client>(DAL.Client.GetClient(rfc)).ToList();

                Object[] seguridad = new Object[2];
                Object[] comprobanteProducto = new Object[9];
                Object[] comprobanteServicio = new Object[9];
                Object[] emisor = new Object[1];
                Object[] receptor = new Object[12];
                Object[] impuestostrasladados = new Object[1];
                Object[] impuestosretenidos = new Object[1];
                Object[] impuestot1 = new Object[3];
                Object[] impuestor1 = new Object[2];

                /********** Comienza Object Seguridad **********/
                seguridad[0] = ConfigurationManager.AppSettings["userTimbrado"].ToString();
                seguridad[1] = RODHE.Tools.MD5pass.encrypt(ConfigurationManager.AppSettings["cipherpass"].ToString());

                /********** Comienza Object Comprobante **********/
                double descuentoProducto = 0;
                double descuentoServicio = 0;
                String formaPagoProducto = String.Empty;
                String formaPagoServicio = String.Empty;
                listTickets.ForEach(x =>
                    {
                        if (x.isService == 0)
                        {
                            descuentoProducto += x.descuentoQuantity;
                        }
                        else
                        {
                            descuentoServicio += x.descuentoQuantity;
                        }
                    });



                listTickets.OrderBy(x => x.totalItemsIVA).ToList().ForEach(x =>
                      {
                          if (x.isService == 0)
                          {

                              if (!formaPagoProducto.Contains(GetMethodPaySAT(x.formaPago)))
                                  formaPagoProducto += GetMethodPaySAT(x.formaPago) + ",";
                          }
                          else
                          {
                              if (!formaPagoServicio.Contains(GetMethodPaySAT(x.formaPago)))
                                  formaPagoServicio += GetMethodPaySAT(x.formaPago) + ",";
                          }
                      });


                //Object Comprobante Producto
                comprobanteProducto[0] = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss");
                comprobanteProducto[1] = "30 dias";
                comprobanteProducto[2] = descuentoProducto;
                if ((double)comprobanteProducto[2] > 0)
                {
                    comprobanteProducto[3] = "Descuento producto";
                }
                else
                {
                    comprobanteProducto[3] = "";
                }
                comprobanteProducto[4] = formaPagoProducto.TrimEnd(',');
                comprobanteProducto[5] = "1";
                comprobanteProducto[6] = "MXN";
                comprobanteProducto[7] = "CDMX";
                comprobanteProducto[8] = "";
                //Object Comprobante Servicio
                comprobanteServicio[0] = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss");
                comprobanteServicio[1] = "30 dias";
                comprobanteServicio[2] = descuentoServicio;
                if ((double)comprobanteServicio[2] > 0)
                {
                    comprobanteServicio[3] = "Descuento servicio";
                }
                else
                {
                    comprobanteServicio[3] = "";
                }
                comprobanteServicio[4] = formaPagoServicio.TrimEnd(',');
                comprobanteServicio[5] = "1";
                comprobanteServicio[6] = "MXN";
                comprobanteServicio[7] = "CDMX";
                comprobanteServicio[8] = "";

                /********** Comienza Object Receptor **********/
                foreach (var element in listClient)
                {
                    receptor[0] = element.rfc;
                    receptor[1] = element.razonsocial;
                    receptor[2] = element.calle;
                    receptor[3] = element.noexterno;
                    receptor[4] = element.nointerno;
                    receptor[5] = element.colonia;
                    receptor[6] = element.municipio;
                    receptor[7] = element.municipio;
                    receptor[8] = "";
                    receptor[9] = element.estado;
                    receptor[10] = element.pais;
                    receptor[11] = element.cp;
                }

                /********** Comienza Object Emisor **********/
                listTickets.ForEach(x => emisor[0] = x.idsucursal);

                /********** Comienza Object Conceptos **********/
                int tamanoProducto = listTickets.Where(x => x.isService == 0).ToList().Count();
                int tamanoServicio = listTickets.Where(x => x.isService == 1).ToList().Count();
                Object[] conceptoFinalProducto = new Object[tamanoProducto];
                Object[] conceptoFinalServicio = new Object[tamanoServicio];
                int counP = 0;
                int countS = 0;
                //Object Conceptos Producto
                var productos = listTickets.Where(x => x.isService == 0);
                foreach (var ticketsList in productos)
                {
                    Object[] conceptosProducto = new Object[6];
                    conceptosProducto[0] = ticketsList.cantidad;
                    conceptosProducto[1] = "Producto";
                    conceptosProducto[2] = ticketsList.item_id;
                    conceptosProducto[3] = ticketsList.nombre;
                    conceptosProducto[4] = ticketsList.totalitem;
                    conceptosProducto[5] = ticketsList.totalSinIVA;
                    conceptoFinalProducto[counP] = conceptosProducto;
                    counP = counP + 1;
                }
                //Object Conceptos Servicio
                var servicios = listTickets.Where(x => x.isService == 1);
                foreach (var ticketsList in servicios)
                {
                    Object[] conceptosServicio = new Object[6];
                    conceptosServicio[0] = ticketsList.cantidad;
                    conceptosServicio[1] = "Servicio";
                    conceptosServicio[2] = ticketsList.item_id;
                    conceptosServicio[3] = ticketsList.nombre;
                    conceptosServicio[4] = ticketsList.totalitem;
                    conceptosServicio[5] = ticketsList.totalSinIVA;
                    conceptoFinalServicio[countS] = conceptosServicio;
                    countS = countS + 1;
                }

                /********** Comienza Object Impuestos **********/
                Object[] impuestoFinalProducto = new Object[tamanoProducto];
                Object[] impuestoFinalServicio = new Object[tamanoServicio];
                counP = 0;
                countS = 0;
                //Object Impuestos Producto
                foreach (var impuestosList in productos)
                {
                    Object[] impuestosProducto = new Object[3];
                    impuestosProducto[0] = "IVA";
                    impuestosProducto[1] = impuestosList.IVA;
                    impuestosProducto[2] = impuestosList.totalItemsIVA;
                    impuestoFinalProducto[counP] = impuestosProducto;
                    counP = counP + 1;
                }
                //Object Impuestos Servicio
                foreach (var impuestosList in servicios)
                {
                    Object[] impuestosServicio = new Object[3];
                    impuestosServicio[0] = "IVA";
                    impuestosServicio[1] = impuestosList.IVA;
                    impuestosServicio[2] = impuestosList.totalItemsIVA;
                    impuestoFinalServicio[countS] = impuestosServicio;
                    countS = countS + 1;
                }

                /********** Comienzan Peticiones al Web Service **********/
                //Si hay productos hacemos factura de otro modo vamos al caso de facturar un servicio
                if (conceptoFinalProducto.Length > 0)
                {
                    ServiceFacturacion.WebServiceCFDI servicio = new ServiceFacturacion.WebServiceCFDI();
                    servicio.Url = ConfigurationManager.AppSettings["UrlCFDI"].ToString();
                    servicio.Timeout = Convert.ToInt32(ConfigurationManager.AppSettings["UrlCFDItimeout"].ToString());
                    //Solicita Factura PRODUCTO
                    Object[] respuestaProducto = servicio.timbrarv1(seguridad, comprobanteProducto, emisor, receptor, conceptoFinalProducto, impuestoFinalProducto, null);
                    if ((int)respuestaProducto[0] == 1)
                    {
                        byte[] xml = Convert.FromBase64String(respuestaProducto[1].ToString());
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(System.Text.UTF8Encoding.UTF8.GetString(xml));
                        var nsManager = new XmlNamespaceManager(doc.NameTable);
                        nsManager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
                        nsManager.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");
                        String UUIDProducto = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@UUID", nsManager).Value;
                        String folioProducto = doc.SelectSingleNode("/cfdi:Comprobante/@folio", nsManager).Value;
                        DateTime fechaFacturaProducto = Convert.ToDateTime(doc.SelectSingleNode("/cfdi:Comprobante/@fecha", nsManager).Value);
                        //Insertar información de factura
                        List<string> listcve = listTickets.Select(x => x.cve_ticket).ToList();
                        foreach (var item in listcve.GroupBy(x => x))
                        {
                            DAL.Ticket.AddTicketFacturado(folioProducto, item.Key, fechaFacturaProducto, UUIDProducto, rfc, "productos");
                        }
                        //Guardar archivo de facturas en Azure
                        string clientestorage = ConfigurationManager.AppSettings["clientestorage"].ToString();
                        BLL.AzureStorage.StoreXml(doc, clientestorage + UUIDProducto);
                        BLL.AzureStorage.StorePdf(respuestaProducto[2].ToString(), clientestorage + UUIDProducto);

                        result.Status = RODHE.Facturacion.OBJ.Status.sucess;
                        result.Message = "Facturación realizada correctamente.";
                        result.BodyProducto = UUIDProducto;
                        result.IDProducto = UUIDProducto;
                    }
                    else
                    {
                        result.Status = RODHE.Facturacion.OBJ.Status.error;
                        result.Message = respuestaProducto[2].ToString();
                        result.BodyProducto = null;
                        result.IDProducto = null;
                    }
                }
                else
                {
                    result.BodyProducto = null;
                    result.IDProducto = null;
                }
                //Si existe algún servicio hacemos la factura de otra forma no se realiza ninguna acción
                if (conceptoFinalServicio.Length > 0)
                {
                    ServiceFacturacion.WebServiceCFDI servicio = new ServiceFacturacion.WebServiceCFDI();
                    servicio.Url = ConfigurationManager.AppSettings["UrlCFDI"].ToString();
                    servicio.Timeout = Convert.ToInt32(ConfigurationManager.AppSettings["UrlCFDItimeout"].ToString());
                    //Solicita Factura PRODUCTO
                    Object[] respuestaServicio = servicio.timbrarv1(seguridad, comprobanteServicio, emisor, receptor, conceptoFinalServicio, impuestoFinalServicio, null);
                    if ((int)respuestaServicio[0] == 1)
                    {
                        byte[] xml = Convert.FromBase64String(respuestaServicio[1].ToString());
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(System.Text.UTF8Encoding.UTF8.GetString(xml));
                        var nsManager = new XmlNamespaceManager(doc.NameTable);
                        nsManager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
                        nsManager.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");
                        String UUIDServicio = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@UUID", nsManager).Value;
                        String folioServicio = doc.SelectSingleNode("/cfdi:Comprobante/@folio", nsManager).Value;
                        DateTime fechaFacturaServicio = Convert.ToDateTime(doc.SelectSingleNode("/cfdi:Comprobante/@fecha", nsManager).Value);
                        //Insertar información de factura
                        List<string> listcve = listTickets.Select(x => x.cve_ticket).ToList();
                        foreach (var item in listcve.GroupBy(x => x))
                        {
                            DAL.Ticket.AddTicketFacturado(folioServicio, item.Key, fechaFacturaServicio, UUIDServicio, rfc, "servicios");
                        }
                        //Guardar archivo de facturas en Azure
                        string clientestorage = ConfigurationManager.AppSettings["clientestorage"].ToString();
                        BLL.AzureStorage.StoreXml(doc, clientestorage + UUIDServicio);
                        BLL.AzureStorage.StorePdf(respuestaServicio[2].ToString(), clientestorage + UUIDServicio);

                        result.Status = RODHE.Facturacion.OBJ.Status.sucess;
                        result.Message = "Facturación realizada correctamente.";
                        result.BodyServicio = UUIDServicio;
                        result.IDServicio = UUIDServicio;
                    }
                    else
                    {
                        result.Status = RODHE.Facturacion.OBJ.Status.error;
                        result.Message = respuestaServicio[2].ToString();
                        result.BodyServicio = null;
                        result.IDServicio = null;
                    }
                }
                else
                {
                    result.BodyServicio = null;
                    result.IDServicio = null;
                }
            }
            catch (Exception ex)
            {
                result.Status = RODHE.Facturacion.OBJ.Status.error;
                result.Message = "No se logro facturar, intente más tarde." + ex.Message;
            }
            return result;
        }

        public static byte[] GetFactura(string RFC, string Folio, string DocumentType, string TypeFile)
        {
            try
            {
                byte[] dd = null;
                return dd;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string GetMethodPaySAT(string methodpay)
        {
            string result = string.Empty;

            switch (methodpay)
            {
                case "Efectivo":
                    result = "01";
                    break;
                case "Cheque":
                    result = "02";
                    break;
                case "Transferencia electrónica de fondos":
                    result = "03";
                    break;
                case "Tarjeta de Crédito":
                    result = "04";
                    break;
                case "Monedero Electrónico":
                    result = "05";
                    break;
                case "Dinero electrónico":
                    result = "06";
                    break;
                case "Vales de despensa":
                    result = "08";
                    break;
                case "Tarjeta de Débito":
                    result = "28";
                    break;
                case "Tarjeta de Servicio":
                    result = "29";
                    break;
                default:
                    result = "99";
                    break;
            }

            return result;
        }
    }
}
