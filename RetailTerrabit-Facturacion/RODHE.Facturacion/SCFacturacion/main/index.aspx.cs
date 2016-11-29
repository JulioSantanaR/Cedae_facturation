using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SCFacturacion.main
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Branch>> result = new RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Branch>>();
                result = BLL.Branch.GetBranch();

                if (result.Status.Equals(RODHE.Facturacion.OBJ.Status.sucess))
                    foreach (RODHE.Facturacion.OBJ.Branch item in result.Object)
                        sucursal.Items.Add(new ListItem(item.nombre, item.cve_sucursal.ToString()));

                RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Estado>> resultEst = new RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Estado>>();
                resultEst = BLL.Estado.GetEstado();

                if (resultEst.Status.Equals(RODHE.Facturacion.OBJ.Status.sucess))
                    foreach (RODHE.Facturacion.OBJ.Estado item in resultEst.Object)
                        estado.Items.Add(new ListItem(item.nombre, item.clave));

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
        }

        [WebMethod]
        public static RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.InformationTicket>> GetInformationTicket(string numberTicket, string store, string dateTicket, string totalTicket, string rfc)
        {
            RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.InformationTicket>> result = new RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.InformationTicket>>();
            try
            {
                return BLL.Ticket.GetInformationTicket(numberTicket, store, dateTicket, totalTicket, rfc);
            }
            catch (Exception ex)
            {
                result.Status = RODHE.Facturacion.OBJ.Status.error;
                result.Message = ex.Message;
            }
            return result;
        }

        [WebMethod]
        public static RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.TicketCliente>> GetTicket(string rfc, string tickets)
        {
            RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.TicketCliente>> result = new RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.TicketCliente>>();
            try
            {
                return BLL.Ticket.GetTicketCliente(rfc, tickets);
            }
            catch (Exception ex)
            {
                result.Status = RODHE.Facturacion.OBJ.Status.error;
                result.Message = ex.Message;
            }
            return result;
        }

        [WebMethod]
        public static RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Client>> GetClient(string rfc)
        {
            RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Client>> result = new RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Client>>();
            try
            {
                return BLL.Client.GetClient(rfc);
            }
            catch (Exception ex)
            {
                result.Status = RODHE.Facturacion.OBJ.Status.error;
                result.Message = ex.Message;
            }
            return result;
        }

        [WebMethod]
        public static RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Client>> AddClient(string rfc, string razon, string pais, string estado, string municipio
           , string colonia, string calle, string cp, string noexterno, string nointerno, string correo)
        {
            RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Client>> result = new RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Client>>();
            try
            {
                return BLL.Client.AddClient(rfc, razon, pais, estado, municipio, colonia, calle, cp, noexterno,  nointerno,  correo);
            }
            catch (Exception ex)
            {
                result.Status = RODHE.Facturacion.OBJ.Status.error;
                result.Message = ex.Message;
            }
            return result;
        }

        [WebMethod]
        public static RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Ticket>> FacturarProcess(string tickets)
        {
            RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Ticket>> result = new RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Ticket>>();
            try
            {
                return BLL.Factura.FacturarProcess(tickets);
            }
            catch (Exception ex)
            {
                result.Status = RODHE.Facturacion.OBJ.Status.error;
                result.Message = ex.Message;
            }
            return result;
        }

        [WebMethod]
        public static RODHE.Facturacion.OBJ.Control<List<string>> Facturar(string sucursal, string rfc, string razon, string pais, string estado, 
            string municipio,string colonia, string calle, string cp, string noexterno, string nointerno, string correo, string tickets)
        {
            RODHE.Facturacion.OBJ.Control<List<string>> result = new RODHE.Facturacion.OBJ.Control<List<string>>();
            try
            {
                return BLL.Factura.Facturar(sucursal,rfc, razon, pais, estado, municipio, colonia, calle, cp, noexterno,correo,tickets);
            }
            catch (Exception ex)
            {
                result.Status = RODHE.Facturacion.OBJ.Status.error;
                result.Message = ex.Message;
            }
            return result;
        }

    }
}