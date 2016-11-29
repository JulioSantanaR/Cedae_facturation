using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace SCFacturacion.BLL
{
    public class Branch
    {

        public static RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Branch>> GetBranch()
        {

            //string text = System.IO.File.ReadAllText(@"C:\Users\jesus.recoder.CTR\Desktop\Email\Emails.html");
            //RODHE.Tools.Email EMAIL = new RODHE.Tools.Email();
            //EMAIL.From = "facturacion@staclara.com.mx";
            //EMAIL.Html = text;
            //EMAIL.Password = "hotrekito300188";
            //EMAIL.User = "jrecoder.luna@hotmail.com";
            //EMAIL.To = "rekitomoon@gmail.com";
            //EMAIL.Subject = "factura";
            //EMAIL.Host = "smtp.live.com";
            //EMAIL.Port = 25;
            //EMAIL.EnableSsl = true;
            //EMAIL.TimeOut = 100000;

            //RODHE.Tools.ServiceMail.SendMail(EMAIL);

            RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Branch>> list = new RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Branch>>();

            list.Object = RODHE.Tools.DataTabletoClass.ToClassInstanceCollection<RODHE.Facturacion.OBJ.Branch>(DAL.Branch.GetBranch()).ToList();
            if (list.Object.Count > 0)
                list.Status = RODHE.Facturacion.OBJ.Status.sucess;
            else
            {
                list.Status = RODHE.Facturacion.OBJ.Status.failed;
                list.Message = "No se encontraron las sucursales.";
            }

            return list;
        }

    }
}
