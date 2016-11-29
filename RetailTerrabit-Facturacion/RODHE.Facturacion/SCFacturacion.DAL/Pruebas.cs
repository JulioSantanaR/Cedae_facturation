using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SCFacturacion.DAL
{
   public static class Pruebas
    {
       public static int InsertPruebas(string CommandText)
       {
           try
           {
               
               RODHE.Conexion.ConexionMySQL connection = new RODHE.Conexion.ConexionMySQL();
               connection.CommandText = CommandText;            
               return connection.EjecutaNonQueryCommandText();
           }
           catch (Exception ex)
           {
               throw new Exception("DB: " + ex.Message);
           }
       }
    }
}
