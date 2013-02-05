using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace AzureManagementApiClient
{
    public abstract class AzureService : BaseService
    {
        protected readonly IWriter Writer;
        private const string BaseUri = "https://management.core.windows.net";
        private readonly string subscriptionId;
        private readonly X509Certificate certificate;

        protected AzureService(string subscriptionId, X509Certificate certificate, IWriter writer)
        {
            this.subscriptionId = subscriptionId;
            this.certificate = certificate;
            Writer = writer;
        }

        protected HttpWebRequest GetRequest(string service)
        {
            string uri = string.Format("{0}/{1}/services/{2}", BaseUri, subscriptionId, service);
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.ClientCertificates.Add(certificate);
            request.Method = "GET";
            request.ContentType = "application/xml";
            request.Headers.Add("x-ms-version", "2012-08-01");

            return request;
        }
    }
}