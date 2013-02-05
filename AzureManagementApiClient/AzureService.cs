using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace AzureManagementApiClient
{
    public abstract class AzureService : BaseService
    {
        protected readonly IWriter Writer;
        private const string BaseUri = "https://management.core.windows.net";
        private readonly string subscriptionId;

        protected AzureService(string subscriptionId, IWriter writer)
        {
            this.subscriptionId = subscriptionId;
            Writer = writer;
        }

        protected HttpWebRequest GetRequest(string service)
        {
            string uri = string.Format("{0}/{1}/services/{2}", BaseUri, subscriptionId, service);
            var request = (HttpWebRequest)WebRequest.Create(uri);
            X509Certificate certificate = new X509Certificate(@"C:\testcert.cer");
            request.ClientCertificates.Add(certificate);
            request.Method = "GET";
            request.ContentType = "application/xml";
            request.Headers.Add("x-ms-version", "2012-08-01");

            return request;
        }
    }
}