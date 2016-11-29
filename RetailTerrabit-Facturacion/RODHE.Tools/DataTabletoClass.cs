using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;


namespace RODHE.Tools
{
    public class DataTabletoClass
    {
       
     
        /// <summary>
        /// Rellena propiedades de una clase de una fila de un DataTable en el que el nombre de la propiedad coincide con el nombre de la columna de ese DataTable .
        /// Para ello, para cada fila de la DataTable , devolviendo una lista de las clases.
        /// </summary>
        /// <typeparam name = "T"> El tipo de clase que se va a devolver . < / typeparam >
        /// <param name = "dataTable "> DataTable para llenar de . < / param >
        /// <returns > Una lista de ClassType con sus propiedades configuradas con los datos de las columnas correspondientes de la DataTable . </returns >
        public static IList<T> ToClassInstanceCollection<T>(DataTable dataTable) where T : class, new()
        {
            if (!IsValidDatatable(dataTable))
                return new List<T>();

            Type classType = typeof(T);
            IList<PropertyInfo> propertyList = classType.GetProperties();

            // Parameter class has no public properties.
            if (propertyList.Count == 0)
                return new List<T>();

            List<string> columnNames = dataTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToList();

            List<T> result = new List<T>();
            try
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    T classObject = new T();
                    foreach (PropertyInfo property in propertyList)
                    {
                        if (!IsValidObjectData(property, columnNames, row))
                            continue;

                        object propertyValue = System.Convert.ChangeType(
                                row[property.Name],
                                property.PropertyType
                            );

                        property.SetValue(classObject, propertyValue, null);
                    }
                    result.Add(classObject);
                }
                return result;
            }
            catch
            {
                return new List<T>();
            }
        }

        private static bool IsValidObjectData(PropertyInfo Property, List<string> ColumnNames, DataRow Row)
        {
            if (Property == null || // Null check
                !Property.CanWrite ||  // Make sure property isn't read only
                !ColumnNames.Contains(Property.Name) || // If property is a column name
                Row[Property.Name] == System.DBNull.Value) // Don't copy over DBNull
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// Indica si un DataTable especificado es nulo, tiene cero columnas o (opcionalmente) cero filas .
        /// </summary>
        /// <param name = " dataTable "> DataTable comprobar. </param>
        /// <param name = " ignoreZeroRows "> Cuando se define como true , la función devolverá cierto incluso si el número de filas de la tabla es igual a cero. </param>
        /// <returns> False si la hipótesis nula DataTable especificado, tiene cero columnas o cero filas , de lo contrario verdaderos . </returns>
        public static bool IsValidDatatable(DataTable dataTable, bool ignoreZeroRows = false)
        {
            if (dataTable == null)
                return false;
            if (dataTable.Columns.Count == 0)
                return false;
            if (ignoreZeroRows)
                return true;
            if (dataTable.Rows.Count == 0)
                return false;

            return true;
        }

        /// <summary>
        /// Obtiene un atabla HTml apartir de una lista 
        /// </summary>
        /// <typeparam name="T">tipo de Objeto</typeparam>
        /// <param name="list">Lista</param>
        /// <param name="columns">Columnas de la tabla</param>
        /// <returns>html tabla</returns>
        public static string GetMyTable<T>(IEnumerable<T> list, params Func<T, object>[] fxns)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("<TABLE>\n");
            foreach (var item in list)
            {
                sb.Append("<TR>\n");
                foreach (var fxn in fxns)
                {
                    sb.Append("<TD>");
                    sb.Append(fxn(item));
                    sb.Append("</TD>");
                }
                sb.Append("</TR>\n");
            }
            sb.Append("</TABLE>");

            return sb.ToString();
        }


        /// <summary>
        /// Obtiene un atabla HTml apartir de una lista 
        /// </summary>
        /// <typeparam name="T">tipo de Objeto</typeparam>
        /// <param name="list">Lista</param>
        /// <param name="columns">Columnas de la tabla</param>
        /// <returns>filas de una tabla html</returns>
        public static string GetMyTableRows<T>(IEnumerable<T> list, params Func<T, object>[] fxns)
        {

            StringBuilder sb = new StringBuilder();
          
            foreach (var item in list)
            {
                sb.Append("<TR>\n");
                foreach (var fxn in fxns)
                {
                    sb.Append("<TD>");
                    sb.Append(fxn(item));
                    sb.Append("</TD>");
                }
                sb.Append("</TR>\n");
            }
          

            return sb.ToString();
        }
    }
}
