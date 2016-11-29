using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace RODHE.Facturacion.OBJ
{
    public class InformationTicket : Generic
    {
        public InformationTicket()
        {
        }
        public string cve_ticket { get; set; }
        public DateTime fchVta { get; set; }
        public string cve_sucursal { get; set; }
        public int facturado { get; set; }
        public DateTime fchFactura { get; set; }
        public double total { get; set; }
        public string tipo { get; set; }
    }

    public class InformationFacturacion : Generic
    {
        public InformationFacturacion()
        { 
        }
        public string folio { get; set; }
        public string cve_ticket { get; set; }
        public int facturado { get; set; }
        public DateTime fechafactura { get; set; }
        public string UUID { get; set; }
        public string rfc { get; set; }
        public string tipo { get; set; }
    }

    public class Ticket : Generic
    {
        public Ticket()
        {
        }
        public string cve_ticket { get; set; }
        public string nombre { get; set; }
        public string cve_producto { get; set; }
        public double cantidad { get; set; }
        public DateTime fchVta { get; set; }
        public DateTime fchHrFact { get; set; }
        public double totalitem { get; set; }
        public string descuento { get; set; }
        public string formaPago { get; set; }
        public int idsucursal { get; set; }
        public int item_id { get; set; }
        public double totalSinIVA { get; set; }
        public double descuentoQuantity { get; set; }
        public string IVA { get; set; }
        public double totalItemsIVA { get; set; }
        public double total { get; set; }
        public int facturado { get; set; }
        public int facturadoDia { get; set; }        
        public string rfc { get; set; }
        public int isService { get; set; }
    }

    public class TicketCliente : Generic
    {
        public TicketCliente()
        {
        }

        public List<Ticket> ticket { get; set; }
        public Client client { get; set; }
    }

}
