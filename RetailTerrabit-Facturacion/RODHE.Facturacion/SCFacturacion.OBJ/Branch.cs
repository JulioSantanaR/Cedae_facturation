using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace RODHE.Facturacion.OBJ
{
    public class Branch : Generic
    {
        public Branch()
        {
        }
        public string cve_sucursal { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }        
    }
}
