using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCFacturacion.BLL
{
   public class Estado
    {
       public static RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Estado>> GetEstado()
        {
            RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Estado>> list = new RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Estado>>();

            list.Object = RODHE.Tools.DataTabletoClass.ToClassInstanceCollection<RODHE.Facturacion.OBJ.Estado>(DAL.Estado.GetEstado()).ToList();
            if (list.Object.Count > 0)
                list.Status = RODHE.Facturacion.OBJ.Status.sucess;
            else
            {
                list.Status = RODHE.Facturacion.OBJ.Status.failed;
                list.Message = "No se encontraron los Estados.";
            }

            return list;
        }
    }
}
