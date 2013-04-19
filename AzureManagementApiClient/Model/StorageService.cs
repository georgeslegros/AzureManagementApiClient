using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;

namespace AzureManagementApiClient.Model
{
    public class StorageService
    {
        public string Url { get; set; }
        public string ServiceName { get; set; }
        public StorageServiceProperties StorageServiceProperties { get; set; }
    }

    public class StorageServices
    {
        [XmlElement("StorageService")]
        public List<StorageService> Services { get; set; }
    }

    public class StorageServiceProperties
    {
        public string Description { get; set; }
        public string AffinityGroup { get; set; }
        public string Label { get; set; }
        public Status Status { get; set; }
        public bool GeoReplicationEnabled { get; set; }
        public string GeoPrimaryRegion { get; set; }
        public string StatusOfPrimary { get; set; }

        public string LastGeoFailoverTime { get; set; }
        public string GeoSecondaryRegion { get; set; }
        public string StatusOfSecondary { get; set; }

   

      
        //<Endpoints>
        //  <Endpoint>storage-service-blob-endpoint</Endpoint>
        //  <Endpoint>storage-service-queue-endpoint</Endpoint>
        //  <Endpoint>storage-service-table-endpoint</Endpoint>
        //</Endpoints>
    
        //<StatusOfPrimary>Available|Unavailable</StatusOfPrimary>
        //<LastGeoFailoverTime>DateTime</LastGeoFailoverTime>
        //<GeoSecondaryRegion>secondary-region</GeoSecondaryRegion>
        //<StatusOfSecondary>Available|Unavailable</StatusOfSecondary>
    }

	public class FirewallRule
	{
		public string Name { get; set; }
		public string StartIpAddress { get; set; }
		public string EndIpAddress { get; set; }

//		<FirewallRules xmlns="http://schemas.microsoft.com/sqlazure/2010/12/">
//  <FirewallRule>
//	<Name>Firewall Rule Name</Name>
//	<StartIpAddress>Start IP Addesss Range</StartIpAddress>
//	<EndIpAddress>End IP address Range</EndIpAddress>
//  </FirewallRule>
//</FirewallRules>
	}

   
    public enum Status
    {
        Creating,
        Created,
        Deleting,
        Deleted,
        Changing,
        ResolvingDns
    }
}
