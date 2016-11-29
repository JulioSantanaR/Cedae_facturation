using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SCFacturacion.BLL
{
    public class Ticket
    {
        public static RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.InformationTicket>> GetInformationTicket(string numberTicket, string store, string dateTicket, string totalTicket, string rfc)
        {
            RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.InformationTicket>> list = new RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.InformationTicket>>();
            try
            {
                list.Object = RODHE.Tools.DataTabletoClass.ToClassInstanceCollection<RODHE.Facturacion.OBJ.InformationTicket>(DAL.Ticket.GetInformationTicket(numberTicket, store, dateTicket, totalTicket)).ToList();
                if (list.Object.Count > 0)
                {
                    list.Status = RODHE.Facturacion.OBJ.Status.sucess;
                    //Proceso para agregar ticket a la tabla
                    RODHE.Facturacion.OBJ.InformationTicket tck = list.Object.ToList<RODHE.Facturacion.OBJ.InformationTicket>().FirstOrDefault();
                    if (tck.facturado.Equals(0))
                    {
                        if ((DateTime.Today.AddDays(-(Convert.ToInt32(ConfigurationManager.AppSettings["daysfac"]))) <= tck.fchVta))
                        {

                            IList<RODHE.Facturacion.OBJ.InformationTicket> ilisTCK = list.Object.AsEnumerable<RODHE.Facturacion.OBJ.InformationTicket>().ToList();
                            string table = RODHE.Tools.DataTabletoClass.GetMyTableRows(ilisTCK, x => x.cve_ticket, x => x.fchVta, x => String.Format("{0:C}", x.total), x => "<button onclick=\"remove(this)\" type=\"button\" class=\"btn btn-default\" aria-label=\"Left Align\"><span class=\"fa fa-trash\" aria-hidden=\"true\"></span></button>");

                            list.Status = RODHE.Facturacion.OBJ.Status.sucess;
                            list.Body = table;
                        }
                        else
                        {
                            list.Status = RODHE.Facturacion.OBJ.Status.failed;
                            list.Message = "El ticket no se puede facturar ya que la fecha es mayor a " + ConfigurationManager.AppSettings["daysfac"].ToString() + " días.";
                        }
                    }
                    else
                    {
                        List<RODHE.Facturacion.OBJ.InformationFacturacion> listFacturados = new List<RODHE.Facturacion.OBJ.InformationFacturacion>();
                        listFacturados = RODHE.Tools.DataTabletoClass.ToClassInstanceCollection<RODHE.Facturacion.OBJ.InformationFacturacion>(DAL.Ticket.GetFacturadosInfo(rfc,numberTicket)).ToList();
                        foreach (var item in listFacturados)
                        {
                            if (item.tipo == "productos")
                            {
                                list.Status = RODHE.Facturacion.OBJ.Status.sucess;
                                list.Message = "El ticket ya puede ser descargado.";
                                list.BodyProducto = item.UUID;
                                list.IDProducto = item.folio;
                            }
                            else if (item.tipo == "servicios")
                            {
                                list.Status = RODHE.Facturacion.OBJ.Status.sucess;
                                list.Message = "El ticket ya puede ser descargado.";
                                list.BodyServicio = item.UUID;
                                list.IDServicio = item.folio;
                            }
                            else
                            {
                                list.Status = RODHE.Facturacion.OBJ.Status.failed;
                                list.Message = "El ticket ya fue facturado.";
                            }
                        }
                    }
                }
                else
                {
                    list.Status = RODHE.Facturacion.OBJ.Status.failed;
                    list.Message = "El ticket no existe."+numberTicket.ToString() + "" + store.ToString() + "" + dateTicket.ToString() + "" + totalTicket.ToString();
                }
            }
            catch (Exception ex)
            {
                list.Status = RODHE.Facturacion.OBJ.Status.error;
                list.Message = ex.Message;
            }
            return list;
        }

        public static RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.TicketCliente>> GetTicketCliente(string rfc, string tickets)
        {
            RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.TicketCliente>> list = new RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.TicketCliente>>();
            try
            {
                RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Client>> listClient = new RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Client>>();
                RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Ticket>> listTickets = new RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Ticket>>();
                listTickets = GetTickets(tickets);
                if (listTickets.Status.Equals(RODHE.Facturacion.OBJ.Status.sucess))
                {
                    RODHE.Facturacion.OBJ.Ticket tck = listTickets.Object.ToList<RODHE.Facturacion.OBJ.Ticket>().FirstOrDefault();
                    listClient = BLL.Client.GetClient(rfc);
                    RODHE.Facturacion.OBJ.TicketCliente ticketcliente = new RODHE.Facturacion.OBJ.TicketCliente();
                    List<RODHE.Facturacion.OBJ.TicketCliente> Listticketcliente = new List<RODHE.Facturacion.OBJ.TicketCliente>();
                    ticketcliente.ticket = listTickets.Object.ToList<RODHE.Facturacion.OBJ.Ticket>();
                    ticketcliente.client = (listClient.Object.ToList<RODHE.Facturacion.OBJ.Client>().FirstOrDefault() == null ? new RODHE.Facturacion.OBJ.Client() : listClient.Object.ToList<RODHE.Facturacion.OBJ.Client>().FirstOrDefault());
                    Listticketcliente.Add(ticketcliente);

                    IList<RODHE.Facturacion.OBJ.Ticket> ilisTCK = listTickets.Object.AsEnumerable<RODHE.Facturacion.OBJ.Ticket>().ToList();
                    string table = RODHE.Tools.DataTabletoClass.GetMyTableRows(ilisTCK, x => x.nombre, x => x.cantidad, x => String.Format("{0:C}", x.total));

                    list.Object = Listticketcliente;
                    list.Status = RODHE.Facturacion.OBJ.Status.sucess;
                    list.ID = tickets;
                    list.Body = table;
                }
                else
                {
                    list.Status = RODHE.Facturacion.OBJ.Status.failed;
                    list.Message = listTickets.Message;
                }
            }
            catch (Exception ex)
            {
                list.Status = RODHE.Facturacion.OBJ.Status.error;
                list.Message = ex.Message;
            }
            return list;
        }

        public static RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Ticket>> GetTickets(string numberTickets)
        {
            RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Ticket>> list = new RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Ticket>>();
            try
            {
                list.Object = RODHE.Tools.DataTabletoClass.ToClassInstanceCollection<RODHE.Facturacion.OBJ.Ticket>(DAL.Ticket.GetTickets(numberTickets)).ToList();
                if (list.Object.Count > 0)
                    list.Status = RODHE.Facturacion.OBJ.Status.sucess;
                else
                {
                    list.Status = RODHE.Facturacion.OBJ.Status.failed;
                    list.Message = "Alguno de los tickets no existe desde GetTickets.";
                }
            }
            catch (Exception ex)
            {
                list.Status = RODHE.Facturacion.OBJ.Status.error;
                list.Message = ex.Message;
            }
            return list;
        }

        public static RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Ticket>> GetTicket(string numberTicket, string uuidBranch, string dateTicket, string amountTicket)
        {
            RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Ticket>> list = new RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Ticket>>();
            try
            {
                list.Object = RODHE.Tools.DataTabletoClass.ToClassInstanceCollection<RODHE.Facturacion.OBJ.Ticket>(DAL.Ticket.GetTicket(numberTicket, uuidBranch, dateTicket, amountTicket)).ToList();
                if (list.Object.Count > 0)
                    list.Status = RODHE.Facturacion.OBJ.Status.sucess;
                else
                {
                    list.Status = RODHE.Facturacion.OBJ.Status.failed;
                    list.Message = "El ticket no existe desde GetTicket.";
                }
            }
            catch (Exception ex)
            {
                list.Status = RODHE.Facturacion.OBJ.Status.error;
                list.Message = ex.Message;
            }
            return list;
        }

        public static RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Ticket>> GetTicket(string folio)
        {
            RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Ticket>> list = new RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Ticket>>();
            try
            {
                list.Object = RODHE.Tools.DataTabletoClass.ToClassInstanceCollection<RODHE.Facturacion.OBJ.Ticket>(DAL.Ticket.GetTicket(folio)).ToList();
                if (list.Object.Count > 0)
                    list.Status = RODHE.Facturacion.OBJ.Status.sucess;
                else
                {
                    list.Status = RODHE.Facturacion.OBJ.Status.failed;
                    list.Message = "El ticket no existe.";
                }
            }
            catch (Exception ex)
            {
                list.Status = RODHE.Facturacion.OBJ.Status.error;
                list.Message = ex.Message;
            }
            return list;
        }
    }
}
