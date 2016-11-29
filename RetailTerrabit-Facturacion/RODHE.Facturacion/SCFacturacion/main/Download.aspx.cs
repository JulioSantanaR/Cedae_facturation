using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

namespace SCFacturacion.main
{
    public partial class Download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string uuid = null;
                string ext = null;
                string path = null;
                string clientestorage = ConfigurationManager.AppSettings["clientestorage"].ToString();
                path = "invoices";
                uuid = Request.Params["uuid"].ToString();
                ext = Request.Params["ext"].ToString();
                byte[] archivoB = null;
                try
                {
                    switch (ext)
                    {
                        case "xml":
                            archivoB = BLL.AzureStorage.RetrieveFile(clientestorage + uuid + ".xml", path).ToArray();
                            break;
                        case "pdf":
                            archivoB = BLL.AzureStorage.RetrieveFile(clientestorage + uuid + ".pdf", path).ToArray();
                            break;
                    }
                    Response.Buffer = false;
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.AppendHeader("content-length", archivoB.Length.ToString());

                    if (ext.Equals("xml"))
                        Response.ContentType = "application/xhtml+xml";
                    else
                        Response.ContentType = "application/pdf";
                    string nombre = uuid + "." + ext;
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + nombre);
                    Response.BinaryWrite(archivoB);
                    Response.Flush();
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message + " - No existe el FolioReferencia " + uuid + " para el documento seleccionado");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }

        }
    }
}