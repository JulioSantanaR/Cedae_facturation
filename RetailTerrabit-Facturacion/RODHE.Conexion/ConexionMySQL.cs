using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace RODHE.Conexion
{
    public  class ConexionMySQL
    {

        public ConexionMySQL() { }
            public string CommandText { get; set; }
            public Dictionary<string, string> Parametros { get; set; }
            private MySqlConnection Conn;
            private string ConnectionString;
     
            MySqlConnection IniciaConexion()
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["connectionMySQL"].ConnectionString;
                Conn = new MySqlConnection(ConnectionString);
                if (Conn.State == ConnectionState.Closed)
                    Conn.Open();
                return Conn;
            }

            void CierraConexion()
            {
                Conn.Close();
                Conn.Dispose();
            }

            private void AgregaParametros(MySqlCommand com)
            {
                if (Parametros != null)
                    foreach (KeyValuePair<string, string> item in Parametros)
                        com.Parameters.AddWithValue(item.Key, item.Value);

            }




            #region EjecutaCommandText

            public DataTable EjecutaComandoDataTableCommandText()
            {
                DataTable dt = null;
                using (MySqlCommand command = new MySqlCommand(CommandText, IniciaConexion()))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    dt = new DataTable();
                    da.Fill(dt);
                }
                CierraConexion();
                return dt;
            }

            public DataSet EjecutaComandoDataSetCommandText()
            {
                DataSet ds = null;
                using (MySqlCommand com = new MySqlCommand(CommandText, IniciaConexion()))
                {

                    com.CommandType = System.Data.CommandType.Text;
                    MySqlDataAdapter da = new MySqlDataAdapter(com);
                    ds = new DataSet();
                    da.Fill(ds);
                }
                CierraConexion();
                return ds;
            }

            public int EjecutaNonQueryCommandText()
            {
                int value = -1;
                using (MySqlCommand com = new MySqlCommand(CommandText, IniciaConexion()))
                {
                    com.CommandType = System.Data.CommandType.Text;
                    value = com.ExecuteNonQuery();
                }
                CierraConexion();
                return value;
            }

            public int EjecutaScalarCommandText()
            {
                int value = -1;
                using (MySqlCommand com = new MySqlCommand(CommandText, IniciaConexion()))
                {
                    com.CommandType = System.Data.CommandType.Text;
                    value = Convert.ToInt32(com.ExecuteScalar().ToString());
                }
                CierraConexion();
                return value;
            }

            #endregion EjecutaCommandText

            #region EjecutaSP


            public DataTable EjecutaComandoDataTable()
            {
                DataTable dt = null;
                using (MySqlCommand command = new MySqlCommand(CommandText, IniciaConexion()))
                {
                    AgregaParametros(command);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    dt = new DataTable();
                    da.Fill(dt);
                }
                CierraConexion();
                return dt;
            }

            public DataSet EjecutaComandoDataSet()
            {
                DataSet ds = null;
                using (MySqlCommand com = new MySqlCommand(CommandText, IniciaConexion()))
                {
                    AgregaParametros(com);
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    MySqlDataAdapter da = new MySqlDataAdapter(com);
                    ds = new DataSet();
                    da.Fill(ds);
                }
                CierraConexion();
                return ds;
            }

            public int EjecutaNonQuery()
            {
                int value = -1;
                using (MySqlCommand com = new MySqlCommand(CommandText, IniciaConexion()))
                {
                    AgregaParametros(com);
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    value = com.ExecuteNonQuery();
                }
                CierraConexion();
                return value;
            }

            public int EjecutaScalar()
            {
                int value = -1;
                using (MySqlCommand com = new MySqlCommand(CommandText, IniciaConexion()))
                {
                    AgregaParametros(com);
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    value = Convert.ToInt32(com.ExecuteScalar().ToString());
                }
                CierraConexion();
                return value;
            }

            #endregion

            
        
    }
}
