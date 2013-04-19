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