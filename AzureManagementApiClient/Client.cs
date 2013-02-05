namespace AzureManagementApiClient
{
    public class Client
    {
        private readonly StorageServicesService storageServicesService;

        public Client(string subscriptionId, IWriter writer)
        {
            storageServicesService = new StorageServicesService(subscriptionId, writer);
        }

        public void GetStorageServices()
        {
            storageServicesService.GetStorageServices();
        }
    }
}
