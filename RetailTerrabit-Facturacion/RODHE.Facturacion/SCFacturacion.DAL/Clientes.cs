using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace SCFacturacion.DAL
{
    public class Client
    {
        public static DataTable GetClient(string rfc)
        {
            try
            {

                RODHE.Conexion.ConexionMySQL connection = new RODHE.Conexion.ConexionMySQL();
                connection.CommandText = "sps_clientes";
                connection.Parametros = new Dictionary<string, string>();
                connection.Parametros.Add("@rfcin", rfc.ToString());
                return connection.EjecutaComandoDataTable();
            }
            catch (Exception ex)
            {
                throw new Exception("DB: " + ex.Message);
            }
        }

        public static int AddClient(string rfc, string razon, string pais, string estado, string municipio
           , string colonia, string calle, string cp, string noexterno, string nointerno, string correo)
        {
            try
            {
                RODHE.Conexion.ConexionMySQL connection = new RODHE.Conexion.ConexionMySQL();
                connection.CommandText = "sp_clientes";
                connection.Parametros = new Dictionary<string, string>();
                connection.Parametros.Add("@rfcin", rfc.ToString());
                connection.Parametros.Add("@razonsocialin", razon.ToString());
                connection.Parametros.Add("@paisin", pais.ToString());
                connection.Parametros.Add("@estadoin", estado.ToString());
                connection.Parametros.Add("@municipioin", municipio.ToString());
                connection.Parametros.Add("@coloniain", colonia.ToString());
                connection.Parametros.Add("@callein", calle.ToString());
                connection.Parametros.Add("@cpin", cp.ToString());
                connection.Parametros.Add("@noexternoin", noexterno.ToString());
                connection.Parametros.Add("@nointernoin", nointerno.ToString());
                connection.Parametros.Add("@emailin", correo.ToString());
                return connection.EjecutaNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("DB: " + ex.Message);
            }
        }
    }
}
