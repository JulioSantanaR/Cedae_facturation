using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace SCFacturacion.DAL
{
    public class Branch
    {
        public static DataTable GetBranch()
        {
            try
            {
                RODHE.Conexion.ConexionMySQL connection = new RODHE.Conexion.ConexionMySQL();
                connection.CommandText = "sps_sucursal";                
                return connection.EjecutaComandoDataTable();
            }
            catch (Exception ex)
            {
                throw new Exception("DB: " + ex.Message);
            }
        }
    }
}
