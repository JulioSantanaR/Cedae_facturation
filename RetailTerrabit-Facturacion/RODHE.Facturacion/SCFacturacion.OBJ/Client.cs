using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace RODHE.Facturacion.OBJ
{
    public class Client : Generic
    {
        public Client()
        {
        }
        public int cve_cliente { get; set; }
        public string rfc { get; set; }
        public string razonsocial { get; set; }
        public string pais { get; set; }
        public string estado { get; set; }
        public string municipio { get; set; }       
        public string colonia { get; set; }
        public string calle { get; set; }
        public string noexterno { get; set; }
        public string nointerno { get; set; }
        public string cp { get; set; }
        public string email { get; set; }
    }
}
