using System.Security.Cryptography.X509Certificates;

namespace AzureManagementApiClient
{
    public class Client
    {
        private readonly StorageServicesService storageServicesService;
	    private readonly FirewallRulesService firewallRulesService;

        public Client(string subscriptionId, X509Certificate certificate, IWriter writer)
        {
            storageServicesService = new StorageServicesService(subscriptionId, certificate, writer);
			firewallRulesService = new FirewallRulesService(subscriptionId, certificate, writer);
        }

        public void GetStorageServices()
        {
            storageServicesService.GetStorageServices();
        }

        public void GetStorageService(string serviceName)
        {
            storageServicesService.GetStorageService(serviceName);
        }

		public void GetFirewallRules(string serverName)
		{
			firewallRulesService.GetFirewallRules(serverName);
		}
    }
}
