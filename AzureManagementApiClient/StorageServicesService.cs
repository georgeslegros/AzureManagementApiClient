using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using AzureManagementApiClient.Model;

namespace AzureManagementApiClient
{
    public class StorageServicesService : AzureService
    {
        public StorageServicesService(string subscriptionId, X509Certificate certificate, IWriter writer)
            : base(subscriptionId,certificate, writer)
        { }

        public List<StorageService> GetStorageServices()
        {
            var request = ServiceUri.StorageServices().CreateRequest(certificate);
            var response = ExecuteRequest(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var services = response.DeserializeContent<List<StorageService>>();
                return services;
            }
            return null;
        }

        public StorageService GetStorageService(string serviceName)
        {
            var request = ServiceUri.StorageServices().StorageService(serviceName).CreateRequest(certificate);
    
            var response = ExecuteRequest(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var service = response.DeserializeContent<StorageService>();
                return service;
            }
            return null;
        }
    }

	public class FirewallRulesService : AzureService
	{
		public FirewallRulesService(string subscriptionId, X509Certificate certificate, IWriter writer) 
			: base(subscriptionId, certificate, writer)
		{
		}

		public void GetFirewallRules(string serverName)
		{
			Writer.WriteLine("Getting rules for " + serverName);
			var request = new ServerUri(subscriptionId, serverName).FirewallRules().CreateRequest(certificate);

			var response = ExecuteRequest(request);
			if (response.StatusCode == HttpStatusCode.OK)
			{
				var rules = response.DeserializeContent<List<FirewallRule>>();

				foreach (var firewallRule in rules)
				{
					Writer.WriteLine(firewallRule.Name);
				}
				//return service;
				Writer.WriteLine(response.StatusDescription);
			
			}
			else
			{
				Writer.WriteLine(response.StatusDescription);
			}
			//return null;
		}
	}

    public class HostedServicesService : AzureService
    {
        public HostedServicesService(string subscriptionId, X509Certificate certificate, IWriter writer) 
            : base(subscriptionId, certificate, writer)
        {
        }

        public List<HostedService> GetHostedServices()
        {

            return new List<HostedService>();
        } 
    }

    public class HostedService
    {
        
    }
}