using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace RODHE.Conexion
{
    public class ConexionSQL
    {
        public string CommandText { get; set; }
        public Dictionary<string, string> Parametros { get; set; }
        private SqlConnection Conn;
        private string ConnectionString;

        public ConexionSQL() { }

        SqlConnection IniciaConexion()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["connectionSQL"].ConnectionString;
            Conn = new SqlConnection(ConnectionString);
            if (Conn.State == ConnectionState.Closed)
                Conn.Open();
            return Conn;
        }

        void CierraConexion()
        {
            Conn.Close();
            Conn.Dispose();
        }

        private void AgregaParametros(SqlCommand com)
        {
            if (Parametros != null)
                foreach (KeyValuePair<string, string> item in Parametros)
                    com.Parameters.AddWithValue(item.Key, item.Value);

        }

        #region EjecutaSP


        public DataTable EjecutaComandoDataTable()
        {
            DataTable dt = null;
            using (SqlCommand command = new SqlCommand(CommandText, IniciaConexion()))
            {
                AgregaParametros(command);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                dt = new DataTable();
                da.Fill(dt);
            }
            CierraConexion();
            return dt;
        }

        public DataSet EjecutaComandoDataSet()
        {
            DataSet ds = null;
            using (SqlCommand com = new SqlCommand(CommandText, IniciaConexion()))
            {
                AgregaParametros(com);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                ds = new DataSet();
                da.Fill(ds);
            }
            CierraConexion();
            return ds;
        }

        public int EjecutaNonQuery()
        {
            int value = -1;
            using (SqlCommand com = new SqlCommand(CommandText, IniciaConexion()))
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
            using (SqlCommand com = new SqlCommand(CommandText, IniciaConexion()))
            {
                AgregaParametros(com);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                value = Convert.ToInt32(com.ExecuteScalar().ToString());
            }
            CierraConexion();
            return value;
        }

        #endregion

        #region EjecutaCommandText

        public DataTable EjecutaComandoDataTableCommandText()
        {
            DataTable dt = null;
            using (SqlCommand command = new SqlCommand(CommandText, IniciaConexion()))
            {
                command.CommandType = System.Data.CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(command);
                dt = new DataTable();
                da.Fill(dt);
            }
            CierraConexion();
            return dt;
        }

        public DataSet EjecutaComandoDataSetCommandText()
        {
            DataSet ds = null;
            using (SqlCommand com = new SqlCommand(CommandText, IniciaConexion()))
            {

                com.CommandType = System.Data.CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com);
                ds = new DataSet();
                da.Fill(ds);
            }
            CierraConexion();
            return ds;
        }

        public int EjecutaNonQueryCommandText()
        {
            int value = -1;
            using (SqlCommand com = new SqlCommand(CommandText, IniciaConexion()))
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
            using (SqlCommand com = new SqlCommand(CommandText, IniciaConexion()))
            {
                com.CommandType = System.Data.CommandType.StoredProcedure;
                value = Convert.ToInt32(com.ExecuteScalar().ToString());
            }
            CierraConexion();
            return value;
        }

        #endregion
    }

}
