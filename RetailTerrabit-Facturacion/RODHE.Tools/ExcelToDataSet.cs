using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;


namespace RODHE.Tools
{
    public class ExcelToDataSet
    {
        public DataSet getDataSet(string filePath, Format formato, bool isFirstRowAsColumnNames)
        {
            try
            {
                FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                Excel.IExcelDataReader excelReader = null;
                if (formato.Equals(Format.Xls))
                    excelReader = Excel.ExcelReaderFactory.CreateBinaryReader(stream);
                else
                    excelReader = Excel.ExcelReaderFactory.CreateOpenXmlReader(stream);
                if (isFirstRowAsColumnNames)
                    excelReader.IsFirstRowAsColumnNames = true;
                else
                    excelReader.IsFirstRowAsColumnNames = false;
                DataSet result = excelReader.AsDataSet();
                excelReader.Close();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public enum Format
        {
            Xls,
            Xlsx
        }
    }
}
