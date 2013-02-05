using System.Security.Cryptography.X509Certificates;

namespace AzureManagementApiClient
{
    public class Client
    {
        private readonly StorageServicesService storageServicesService;

        public Client(string subscriptionId, X509Certificate certificate, IWriter writer)
        {
            storageServicesService = new StorageServicesService(subscriptionId, certificate, writer);
        }

        public void GetStorageServices()
        {
            storageServicesService.GetStorageServices();
        }

        public void GetStorageService(string serviceName)
        {
            storageServicesService.GetStorageService(serviceName);
        }
    }
}
