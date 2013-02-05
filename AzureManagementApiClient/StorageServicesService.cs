using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace AzureManagementApiClient
{
    public class StorageServicesService : AzureService
    {
        public StorageServicesService(string subscriptionId, X509Certificate certificate, IWriter writer)
            : base(subscriptionId,certificate, writer)
        { }

        public void GetStorageServices()
        {
            var request = GetRequest("storageservices");
            HttpStatusCode statusCode;
            var responseBody = ExecuteRequest(request, out statusCode);

            if (statusCode.Equals(HttpStatusCode.OK))
            {
                XNamespace wa = "http://schemas.microsoft.com/windowsazure";
                XElement storageServices = responseBody.Element(wa + "StorageServices");
                int storageCount = 0;
                foreach (XElement storageService in storageServices.Elements(wa + "StorageService"))
                {
                    string url = storageService.Element(wa + "Url").Value;
                    string serviceName = storageService.Element(wa + "ServiceName").Value;
                    Writer.WriteLine(
                        "Location[{0}]{1}  Name: {2}{1}  DisplayName: {3}",
                        storageCount++, Environment.NewLine, url, serviceName);
                }
            }
            else
            {
                Writer.WriteLine("Call to List Storage Accounts returned an error:");
                Writer.WriteLine("Status Code: {0} ({1}):{2}{3}",
                                 (int)statusCode, statusCode, Environment.NewLine,
                                 responseBody.ToString(SaveOptions.OmitDuplicateNamespaces));
            }
        }
    }
}