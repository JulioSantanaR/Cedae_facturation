using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCFacturacion.BLL
{
   public class Product
    {
       public static string GetProduct(string rfc)
       {
           try
           {            
               IList<RODHE.Facturacion.OBJ.Client> list = RODHE.Tools.DataTabletoClass.ToClassInstanceCollection<RODHE.Facturacion.OBJ.Client>(DAL.Client.GetClient(rfc));
               return RODHE.Tools.DataTabletoClass.GetMyTableRows(list, x => x.cve_cliente, x => x.razonsocial, x => x.rfc);
           }
           catch (Exception)
           {

               throw;
           }


       }
    }
}
