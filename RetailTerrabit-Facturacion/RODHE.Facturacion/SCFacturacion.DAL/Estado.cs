using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace SCFacturacion.DAL
{
    public class Estado
    {
        public static DataTable GetEstado()
        {
            try
            {
                RODHE.Conexion.ConexionMySQL connection = new RODHE.Conexion.ConexionMySQL();
                connection.CommandText = "sps_estado";
                return connection.EjecutaComandoDataTable();
            }
            catch (Exception ex)
            {
                throw new Exception("DB: " + ex.Message);
            }
        }
    }
}
