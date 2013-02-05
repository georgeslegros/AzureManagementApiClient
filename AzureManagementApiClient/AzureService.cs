using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace AzureManagementApiClient
{
    public abstract class AzureService : BaseService
    {
        protected readonly IWriter Writer;
        private readonly string subscriptionId;
        private readonly X509Certificate certificate;
        protected ServiceUri ServiceUri;

        protected AzureService(string subscriptionId, X509Certificate certificate, IWriter writer)
        {
            this.subscriptionId = subscriptionId;
            this.certificate = certificate;
            Writer = writer;
            ServiceUri = new ServiceUri(subscriptionId);
        }

        protected HttpWebRequest GetRequest(ServiceUri service)
        {
            var request = (HttpWebRequest)WebRequest.Create(service.ToString());
            request.ClientCertificates.Add(certificate);
            request.Method = "GET";
            request.ContentType = "application/xml";
            request.Headers.Add("x-ms-version", "2012-08-01");

            return request;
        }
    }

    public class ServiceUri
    {
        private const string BaseUri = "https://management.core.windows.net";
        private string currentValue;

        public ServiceUri(string subscriptionId)
        {
            currentValue = string.Format("{0}/{1}/services", BaseUri, subscriptionId);
        }

        private ServiceUri(string current, string newPart)
        {
            currentValue = string.Format("{0}/{1}", current, newPart);
        }

        public ServiceUri StorageServices()
        {
            return new ServiceUri(currentValue, "storageservices");
        }

        public ServiceUri StorageService(string serviceName)
        {
            return new ServiceUri(currentValue, serviceName);
        }

        public override string ToString()
        {
            return currentValue;
        }

    }
}