using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Xml;

namespace SCFacturacion.BLL
{
    public class AzureStorage
    {
        private static CloudBlockBlob GetBlockBlobReference(string filename, string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);
            container.CreateIfNotExists();
            return container.GetBlockBlobReference(filename);
        }

        public static IEnumerable<IListBlobItem> GetListBlobItemReference(string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);
            container.CreateIfNotExists();
            return container.ListBlobs();
        }

        public static void StoreFile(Stream stream, string filename, string containerName)
        {
            var blockBlob = GetBlockBlobReference(filename, containerName);
            blockBlob.UploadFromStream(stream);
        }

        public static MemoryStream RetrieveFile(string filename, string containerName)
        {
            var blockBlob = GetBlockBlobReference(filename, containerName);
            if (!blockBlob.Exists()) throw new Exception(string.Format("El archivo {0} no existe, verifiquelo con el administrador.", filename));
            var ms = new MemoryStream();
            blockBlob.DownloadToStream(ms);
            ms.Position = 0;
            return ms;
        }

        public static string StorePdf(string base64Buffer, string uuid)
        {
            var filename = string.Format("{0}.pdf", uuid);
            var buffer = Convert.FromBase64String(base64Buffer);
            using (var ms = new MemoryStream())
            {
                ms.Write(buffer, 0, buffer.Length);
                ms.Position = 0;
                AzureStorage.StoreFile(ms, filename, "invoices");
            }
            return filename;
        }

        public static string StoreXml(XmlDocument xml, string uuid)
        {
            var filename = string.Format("{0}.xml", uuid);
            using (var ms = new MemoryStream())
            {
                xml.Save(ms);
                ms.Position = 0;
                AzureStorage.StoreFile(ms, filename, "invoices");
            }
            return filename;
        }

        public static string GetInvoiceUUID(XmlDocument xml)
        {
            var nsManager = new XmlNamespaceManager(xml.NameTable);
            nsManager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
            nsManager.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");
            return xml.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@UUID", nsManager).Value;
        }
    }
}
