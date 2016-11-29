using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace RODHE.Facturacion.OBJ
{


    public class Generic
    {
        public string typeControl { get; set; }
        public string Message { get; set; }
        public bool result { get; set; }    
    }


    public class Control<T> where T : class
    {
        public bool Complete { get; set; }
        public string Message { get; set; }
        public string ID { get; set; }
        public string Body { get; set; }
        public Status Status { get; set; }
        public T Object { get; set; }
        public string IDProducto { get; set; }
        public string BodyProducto { get; set; }
        public string IDServicio { get; set; }
        public string BodyServicio { get; set; }
    }

    public enum Status
    {
        sucess = 1,
        blocked = 2,
        incomplete = 3,
        exception = 4,
        error = 5,
        failed = 6
    }
   
}
