using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace AzureManagementApiClient
{
    public abstract class AzureService : BaseService
    {
        protected readonly IWriter Writer;
        private readonly string subscriptionId;
        protected readonly X509Certificate certificate;
        protected ServiceUri ServiceUri;

        protected AzureService(string subscriptionId, X509Certificate certificate, IWriter writer)
        {
            this.subscriptionId = subscriptionId;
            this.certificate = certificate;
            Writer = writer;
            ServiceUri = new ServiceUri(subscriptionId);
        }

        protected HttpWebRequest GetRequest(IUri service)
        {
            var request = (HttpWebRequest)WebRequest.Create(service.Build());
            request.ClientCertificates.Add(certificate);
            request.Method = "GET";
            request.ContentType = "application/xml";
            request.Headers.Add("x-ms-version", "2012-08-01");

            return request;
        }

    }

    public static class UriExtensions
    {
        public static HttpWebRequest CreateRequest(this IUri uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri.Build());
            request.Method = "GET";
            request.ContentType = "application/xml";
            request.Headers.Add("x-ms-version", "2012-08-01");

            return request;
        }

        public static HttpWebRequest CreateRequest(this IUri uri, X509Certificate certificate)
        {
            var request = uri.CreateRequest();
            request.ClientCertificates.Add(certificate);
            return request;
        }
    }

    public interface IUri
    {
        string Build();
    }

    public class ServiceUri : IUri
    {
        private readonly string subscriptionId;
        private const string BaseUri = "https://management.core.windows.net";

        public ServiceUri(string subscriptionId)
        {
            this.subscriptionId = subscriptionId;
        }

        public StorageServicesUri StorageServices()
        {
            return new StorageServicesUri(this);
        }

        public string Build()
        {
            return string.Format("{0}/{1}/services", BaseUri, subscriptionId);
        }
    }
    public class StorageServicesUri : IUri
    {
        private readonly ServiceUri serviceUri;
        private const string StorageServicesPart = "storageservices";

        public StorageServicesUri(ServiceUri serviceUri)
        {
            this.serviceUri = serviceUri;
        }

        public StorageServiceUri StorageService(string serviceName)
        {
            return new StorageServiceUri(this, serviceName);
        }

        public string Build()
        {
            return string.Format("{0}/{1}", serviceUri.Build(), StorageServicesPart);
        }
    }

    public class StorageServiceUri :IUri
    {
        private readonly StorageServicesUri storageServicesUri;
        private readonly string serviceName;

        public StorageServiceUri(StorageServicesUri storageServicesUri, string serviceName)
        {
            this.storageServicesUri = storageServicesUri;
            this.serviceName = serviceName;
        }

        public string Build()
        {
            return string.Format("{0}/{1}", storageServicesUri.Build(), serviceName);
        }
    }
}