using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCFacturacion.BLL
{
    public class Client
    {
        public static RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Client>> GetClient(string rfc)
        {
            RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Client>> list = new RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Client>>(); 
            try
            {               
                  list.Object= RODHE.Tools.DataTabletoClass.ToClassInstanceCollection<RODHE.Facturacion.OBJ.Client>(DAL.Client.GetClient(rfc)).ToList();
                  if (list.Object.Count > 0)
                      list.Status = RODHE.Facturacion.OBJ.Status.sucess;
                  else
                  {
                      list.Status = RODHE.Facturacion.OBJ.Status.failed;
                      list.Message = "No se encontró el cliente.";
                  }                    
            }
            catch (Exception ex)
            {
                list.Status = RODHE.Facturacion.OBJ.Status.error;
                list.Message = ex.Message;
            }
            return list; 
        }

        public static RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Client>> AddClient(string rfc, string razon, string pais, string estado, string municipio
           , string colonia, string calle, string cp, string noexterno, string nointerno, string correo)
        {
            RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Client>> list = new RODHE.Facturacion.OBJ.Control<List<RODHE.Facturacion.OBJ.Client>>();
            try
            {
                DAL.Client.AddClient(rfc,razon,pais,estado,municipio,colonia,calle,cp,noexterno,nointerno,correo);               
                
                    list.Status = RODHE.Facturacion.OBJ.Status.sucess;               
                    list.Message = "Se guardaron correctamente sus datos.";
              
            }
            catch (Exception ex)
            {
                list.Status = RODHE.Facturacion.OBJ.Status.error;
                list.Message = ex.Message;
            }
            return list; 
        }
    }
}
