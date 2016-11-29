using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace SCFacturacion.DAL
{
    public class Ticket
    {
        public static DataTable GetInformationTicket(string numberTicket, string store, string dateTicket, string totalTicket)
        {
            try
            {

                RODHE.Conexion.ConexionMySQL connection = new RODHE.Conexion.ConexionMySQL();
                connection.CommandText = "sps_informationTicket";
                connection.Parametros = new Dictionary<string, string>();
                connection.Parametros.Add("@tcknum", numberTicket);
                connection.Parametros.Add("@cve_sucursal", store);
                connection.Parametros.Add("@tckfecha", dateTicket);
                connection.Parametros.Add("@monto", totalTicket);
                return connection.EjecutaComandoDataTable();
            }
            catch (Exception ex)
            {
                throw new Exception("DB: " + ex.Message);
            }
        }

        public static DataTable GetTickets(string numberTickets)
        {
            try
            {

                RODHE.Conexion.ConexionMySQL connection = new RODHE.Conexion.ConexionMySQL();
                connection.CommandText = "sps_items";
                connection.Parametros = new Dictionary<string, string>();
                connection.Parametros.Add("@arreglo", numberTickets);
                return connection.EjecutaComandoDataTable();
            }
            catch (Exception ex)
            {
                throw new Exception("DB: " + ex.Message);
            }
        }

        public static DataTable GetFacturadosInfo(string rfc, string cve_ticket)
        {
            try
            {

                RODHE.Conexion.ConexionMySQL connection = new RODHE.Conexion.ConexionMySQL();
                connection.CommandText = "sps_facturados";
                connection.Parametros = new Dictionary<string, string>();
                connection.Parametros.Add("@rfcin", rfc);
                connection.Parametros.Add("@ticketin", cve_ticket);
                return connection.EjecutaComandoDataTable();
            }
            catch (Exception ex)
            {
                throw new Exception("DB: " + ex.Message);
            }
        }

        public static DataTable GetTicket(string numberTicket, string uuidBranch, string dateTicket, string amountTicket)
        {
            try
            {

                RODHE.Conexion.ConexionMySQL connection = new RODHE.Conexion.ConexionMySQL();
                connection.CommandText = "sps_ticket";
                connection.Parametros = new Dictionary<string, string>();
                connection.Parametros.Add("@folio", null);
                connection.Parametros.Add("@tcknum", numberTicket);
                connection.Parametros.Add("@cve_sucursal", uuidBranch);
                connection.Parametros.Add("@tckfecha", dateTicket);
                connection.Parametros.Add("@monto", amountTicket);
                return connection.EjecutaComandoDataTable();
            }
            catch (Exception ex)
            {
                throw new Exception("DB: " + ex.Message);
            }
        }

        public static DataTable GetTicket(string folio)
        {
            try
            {

                RODHE.Conexion.ConexionMySQL connection = new RODHE.Conexion.ConexionMySQL();
                connection.CommandText = "sps_ticket";
                connection.Parametros = new Dictionary<string, string>();
                connection.Parametros.Add("@folio", folio);
                connection.Parametros.Add("@tcknum", null);
                connection.Parametros.Add("@cve_sucursal", null);
                connection.Parametros.Add("@tckfecha", null);
                connection.Parametros.Add("@monto", null);
                return connection.EjecutaComandoDataTable();
            }
            catch (Exception ex)
            {
                throw new Exception("DB: " + ex.Message);
            }
        }

        public static int UpdateTicket(string folio, string rfc, string email, string cve_ticket, string notienda, string xmlfac, string xmlnc)
        {
            try
            {

                RODHE.Conexion.ConexionMySQL connection = new RODHE.Conexion.ConexionMySQL();
                connection.CommandText = "usp_ticketUpdate";
                connection.Parametros = new Dictionary<string, string>();
                connection.Parametros.Add("@folio", folio);
                connection.Parametros.Add("@rfc", rfc);
                connection.Parametros.Add("@email", email);
                connection.Parametros.Add("@cve_ticket", cve_ticket);
                connection.Parametros.Add("@notienda", notienda);
                connection.Parametros.Add("@xmlfac", xmlfac);      
                connection.Parametros.Add("@xmlnc", xmlnc.Equals("") ? null : xmlnc);
                return connection.EjecutaNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("DB: " + ex.Message);
            }
        }

        public static int AddTicketFacturado(string folioin, string cve_ticketin, DateTime fechafacturain, string UUIDin,string rfcin, string tipoin)
        {
            try
            {
                RODHE.Conexion.ConexionMySQL connection = new RODHE.Conexion.ConexionMySQL();
                connection.CommandText = "spi_facturados";
                connection.Parametros = new Dictionary<string, string>();
                connection.Parametros.Add("@folioin", folioin);
                connection.Parametros.Add("@cve_ticketin", cve_ticketin);
                connection.Parametros.Add("@fechafacturain", fechafacturain.ToString("yyyy-MM-dd hh:mm:ss"));
                connection.Parametros.Add("@UUIDin", UUIDin);
                connection.Parametros.Add("@rfcin", rfcin);
                connection.Parametros.Add("@tipoin", tipoin);
                return connection.EjecutaNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("DB: " + ex.Message);
            }
        }

    }
}
