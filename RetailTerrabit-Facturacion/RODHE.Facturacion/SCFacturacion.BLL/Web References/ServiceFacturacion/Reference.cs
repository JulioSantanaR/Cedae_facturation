﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace SCFacturacion.BLL.ServiceFacturacion {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WebServiceCFDISoap", Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(object[]))]
    public partial class WebServiceCFDI : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback timbrarv1OperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WebServiceCFDI() {
            this.Url = global::SCFacturacion.BLL.Properties.Settings.Default.SCFacturacion_BLL_ServiceFacturacion_WebServiceCFDI;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event timbrarv1CompletedEventHandler timbrarv1Completed;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/timbrarv1", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public object[] timbrarv1(object[] Seguridad, object[] Comprobante, object[] Emisor, object[] Receptor, object[] Conceptos, object[] ImpuestosTrasladados, object[] ImpuestosRetenidos) {
            object[] results = this.Invoke("timbrarv1", new object[] {
                        Seguridad,
                        Comprobante,
                        Emisor,
                        Receptor,
                        Conceptos,
                        ImpuestosTrasladados,
                        ImpuestosRetenidos});
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        public void timbrarv1Async(object[] Seguridad, object[] Comprobante, object[] Emisor, object[] Receptor, object[] Conceptos, object[] ImpuestosTrasladados, object[] ImpuestosRetenidos) {
            this.timbrarv1Async(Seguridad, Comprobante, Emisor, Receptor, Conceptos, ImpuestosTrasladados, ImpuestosRetenidos, null);
        }
        
        /// <remarks/>
        public void timbrarv1Async(object[] Seguridad, object[] Comprobante, object[] Emisor, object[] Receptor, object[] Conceptos, object[] ImpuestosTrasladados, object[] ImpuestosRetenidos, object userState) {
            if ((this.timbrarv1OperationCompleted == null)) {
                this.timbrarv1OperationCompleted = new System.Threading.SendOrPostCallback(this.Ontimbrarv1OperationCompleted);
            }
            this.InvokeAsync("timbrarv1", new object[] {
                        Seguridad,
                        Comprobante,
                        Emisor,
                        Receptor,
                        Conceptos,
                        ImpuestosTrasladados,
                        ImpuestosRetenidos}, this.timbrarv1OperationCompleted, userState);
        }
        
        private void Ontimbrarv1OperationCompleted(object arg) {
            if ((this.timbrarv1Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.timbrarv1Completed(this, new timbrarv1CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void timbrarv1CompletedEventHandler(object sender, timbrarv1CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class timbrarv1CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal timbrarv1CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public object[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((object[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591