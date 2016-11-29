using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCFacturacion.OBJ
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3", IsNullable = false)]
    public partial class Comprobante
    {

        private ComprobanteEmisor emisorField;
        private ComprobanteReceptor receptorField;
        private ComprobanteConceptos conceptosField;
        private ComprobanteImpuestos impuestosField;
        private ComprobanteComplemento complementoField;
        private decimal versionField;
        private string serieField;
        private byte folioField;
        private System.DateTime fechaField;
        private string selloField;
        private string formaDePagoField;
        private string noCertificadoField;
        private string certificadoField;
        private string condicionesDePagoField;
        private decimal subTotalField;
        private byte tipoCambioField;
        private string monedaField;
        private decimal totalField;
        private string tipoDeComprobanteField;
        private string metodoDePagoField;
        private string lugarExpedicionField;

        /// <remarks/>
        public ComprobanteEmisor Emisor
        {
            get
            {
                return this.emisorField;
            }
            set
            {
                this.emisorField = value;
            }
        }

        /// <remarks/>
        public ComprobanteReceptor Receptor
        {
            get
            {
                return this.receptorField;
            }
            set
            {
                this.receptorField = value;
            }
        }

        /// <remarks/>
        public ComprobanteConceptos Conceptos
        {
            get
            {
                return this.conceptosField;
            }
            set
            {
                this.conceptosField = value;
            }
        }

        /// <remarks/>
        public ComprobanteImpuestos Impuestos
        {
            get
            {
                return this.impuestosField;
            }
            set
            {
                this.impuestosField = value;
            }
        }

        /// <remarks/>
        public ComprobanteComplemento Complemento
        {
            get
            {
                return this.complementoField;
            }
            set
            {
                this.complementoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string serie
        {
            get
            {
                return this.serieField;
            }
            set
            {
                this.serieField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte folio
        {
            get
            {
                return this.folioField;
            }
            set
            {
                this.folioField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime fecha
        {
            get
            {
                return this.fechaField;
            }
            set
            {
                this.fechaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string sello
        {
            get
            {
                return this.selloField;
            }
            set
            {
                this.selloField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string formaDePago
        {
            get
            {
                return this.formaDePagoField;
            }
            set
            {
                this.formaDePagoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string noCertificado
        {
            get
            {
                return this.noCertificadoField;
            }
            set
            {
                this.noCertificadoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string certificado
        {
            get
            {
                return this.certificadoField;
            }
            set
            {
                this.certificadoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string condicionesDePago
        {
            get
            {
                return this.condicionesDePagoField;
            }
            set
            {
                this.condicionesDePagoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal subTotal
        {
            get
            {
                return this.subTotalField;
            }
            set
            {
                this.subTotalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte TipoCambio
        {
            get
            {
                return this.tipoCambioField;
            }
            set
            {
                this.tipoCambioField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Moneda
        {
            get
            {
                return this.monedaField;
            }
            set
            {
                this.monedaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal total
        {
            get
            {
                return this.totalField;
            }
            set
            {
                this.totalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string tipoDeComprobante
        {
            get
            {
                return this.tipoDeComprobanteField;
            }
            set
            {
                this.tipoDeComprobanteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string metodoDePago
        {
            get
            {
                return this.metodoDePagoField;
            }
            set
            {
                this.metodoDePagoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LugarExpedicion
        {
            get
            {
                return this.lugarExpedicionField;
            }
            set
            {
                this.lugarExpedicionField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteEmisor
    {

        private ComprobanteEmisorDomicilioFiscal domicilioFiscalField;

        private ComprobanteEmisorRegimenFiscal regimenFiscalField;

        private string rfcField;

        private string nombreField;

        /// <remarks/>
        public ComprobanteEmisorDomicilioFiscal DomicilioFiscal
        {
            get
            {
                return this.domicilioFiscalField;
            }
            set
            {
                this.domicilioFiscalField = value;
            }
        }

        /// <remarks/>
        public ComprobanteEmisorRegimenFiscal RegimenFiscal
        {
            get
            {
                return this.regimenFiscalField;
            }
            set
            {
                this.regimenFiscalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string rfc
        {
            get
            {
                return this.rfcField;
            }
            set
            {
                this.rfcField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string nombre
        {
            get
            {
                return this.nombreField;
            }
            set
            {
                this.nombreField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteEmisorDomicilioFiscal
    {

        private string calleField;

        private ushort noExteriorField;

        private ushort noInteriorField;

        private string coloniaField;

        private string localidadField;

        private string municipioField;

        private string estadoField;

        private string paisField;

        private ushort codigoPostalField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string calle
        {
            get
            {
                return this.calleField;
            }
            set
            {
                this.calleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort noExterior
        {
            get
            {
                return this.noExteriorField;
            }
            set
            {
                this.noExteriorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort noInterior
        {
            get
            {
                return this.noInteriorField;
            }
            set
            {
                this.noInteriorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string colonia
        {
            get
            {
                return this.coloniaField;
            }
            set
            {
                this.coloniaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string localidad
        {
            get
            {
                return this.localidadField;
            }
            set
            {
                this.localidadField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string municipio
        {
            get
            {
                return this.municipioField;
            }
            set
            {
                this.municipioField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string estado
        {
            get
            {
                return this.estadoField;
            }
            set
            {
                this.estadoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string pais
        {
            get
            {
                return this.paisField;
            }
            set
            {
                this.paisField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort codigoPostal
        {
            get
            {
                return this.codigoPostalField;
            }
            set
            {
                this.codigoPostalField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteEmisorRegimenFiscal
    {

        private string regimenField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Regimen
        {
            get
            {
                return this.regimenField;
            }
            set
            {
                this.regimenField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteReceptor
    {

        private ComprobanteReceptorDomicilio domicilioField;

        private string rfcField;

        private string nombreField;

        /// <remarks/>
        public ComprobanteReceptorDomicilio Domicilio
        {
            get
            {
                return this.domicilioField;
            }
            set
            {
                this.domicilioField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string rfc
        {
            get
            {
                return this.rfcField;
            }
            set
            {
                this.rfcField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string nombre
        {
            get
            {
                return this.nombreField;
            }
            set
            {
                this.nombreField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteReceptorDomicilio
    {

        private string calleField;

        private ushort noExteriorField;

        private byte noInteriorField;

        private string coloniaField;

        private string localidadField;

        private string estadoField;

        private string paisField;

        private uint codigoPostalField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string calle
        {
            get
            {
                return this.calleField;
            }
            set
            {
                this.calleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort noExterior
        {
            get
            {
                return this.noExteriorField;
            }
            set
            {
                this.noExteriorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte noInterior
        {
            get
            {
                return this.noInteriorField;
            }
            set
            {
                this.noInteriorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string colonia
        {
            get
            {
                return this.coloniaField;
            }
            set
            {
                this.coloniaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string localidad
        {
            get
            {
                return this.localidadField;
            }
            set
            {
                this.localidadField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string estado
        {
            get
            {
                return this.estadoField;
            }
            set
            {
                this.estadoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string pais
        {
            get
            {
                return this.paisField;
            }
            set
            {
                this.paisField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint codigoPostal
        {
            get
            {
                return this.codigoPostalField;
            }
            set
            {
                this.codigoPostalField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteConceptos
    {

        private ComprobanteConceptosConcepto conceptoField;

        /// <remarks/>
        public ComprobanteConceptosConcepto Concepto
        {
            get
            {
                return this.conceptoField;
            }
            set
            {
                this.conceptoField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteConceptosConcepto
    {

        private decimal cantidadField;

        private string unidadField;

        private string noIdentificacionField;

        private string descripcionField;

        private decimal valorUnitarioField;

        private decimal importeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal cantidad
        {
            get
            {
                return this.cantidadField;
            }
            set
            {
                this.cantidadField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unidad
        {
            get
            {
                return this.unidadField;
            }
            set
            {
                this.unidadField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string noIdentificacion
        {
            get
            {
                return this.noIdentificacionField;
            }
            set
            {
                this.noIdentificacionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string descripcion
        {
            get
            {
                return this.descripcionField;
            }
            set
            {
                this.descripcionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal valorUnitario
        {
            get
            {
                return this.valorUnitarioField;
            }
            set
            {
                this.valorUnitarioField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal importe
        {
            get
            {
                return this.importeField;
            }
            set
            {
                this.importeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteImpuestos
    {

        private ComprobanteImpuestosTraslados trasladosField;

        private decimal totalImpuestosTrasladadosField;

        private decimal totalImpuestosRetenidosField;

        /// <remarks/>
        public ComprobanteImpuestosTraslados Traslados
        {
            get
            {
                return this.trasladosField;
            }
            set
            {
                this.trasladosField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal totalImpuestosTrasladados
        {
            get
            {
                return this.totalImpuestosTrasladadosField;
            }
            set
            {
                this.totalImpuestosTrasladadosField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal totalImpuestosRetenidos
        {
            get
            {
                return this.totalImpuestosRetenidosField;
            }
            set
            {
                this.totalImpuestosRetenidosField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteImpuestosTraslados
    {

        private ComprobanteImpuestosTrasladosTraslado trasladoField;

        /// <remarks/>
        public ComprobanteImpuestosTrasladosTraslado Traslado
        {
            get
            {
                return this.trasladoField;
            }
            set
            {
                this.trasladoField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteImpuestosTrasladosTraslado
    {

        private string impuestoField;

        private byte tasaField;

        private decimal importeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string impuesto
        {
            get
            {
                return this.impuestoField;
            }
            set
            {
                this.impuestoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte tasa
        {
            get
            {
                return this.tasaField;
            }
            set
            {
                this.tasaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal importe
        {
            get
            {
                return this.importeField;
            }
            set
            {
                this.importeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteComplemento
    {

        private TimbreFiscalDigital timbreFiscalDigitalField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital")]
        public TimbreFiscalDigital TimbreFiscalDigital
        {
            get
            {
                return this.timbreFiscalDigitalField;
            }
            set
            {
                this.timbreFiscalDigitalField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital", IsNullable = false)]
    public partial class TimbreFiscalDigital
    {

        private decimal versionField;

        private string uUIDField;

        private System.DateTime fechaTimbradoField;

        private string selloCFDField;

        private string noCertificadoSATField;

        private string selloSATField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string UUID
        {
            get
            {
                return this.uUIDField;
            }
            set
            {
                this.uUIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime FechaTimbrado
        {
            get
            {
                return this.fechaTimbradoField;
            }
            set
            {
                this.fechaTimbradoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string selloCFD
        {
            get
            {
                return this.selloCFDField;
            }
            set
            {
                this.selloCFDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string noCertificadoSAT
        {
            get
            {
                return this.noCertificadoSATField;
            }
            set
            {
                this.noCertificadoSATField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string selloSAT
        {
            get
            {
                return this.selloSATField;
            }
            set
            {
                this.selloSATField = value;
            }
        }
    }


}
