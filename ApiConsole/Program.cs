using System;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using AzureManagementApiClient;

namespace ApiConsole
{
    class Program
    {
        static void Main()
        {
            string subscriptionId = ConfigurationManager.AppSettings["subscriptionId"];
            string serverName = ConfigurationManager.AppSettings["serverName"];
            Client client = new Client(subscriptionId, LoadCertificate(), new ConsoleWriter());
			//client.GetStorageServices();
			//client.GetStorageService("bre");
			Console.WriteLine("BEFORE");
			client.GetFirewallRules(serverName);
			Console.WriteLine("AFTER");
            Console.ReadKey();
        }

        private static X509Certificate LoadCertificate()
        {
            string certificateLocation = ConfigurationManager.AppSettings["certificateLocation"];
            return new X509Certificate(certificateLocation);
        }
    }
}
