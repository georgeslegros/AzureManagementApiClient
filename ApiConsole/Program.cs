using System;
using System.Configuration;
using AzureManagementApiClient;

namespace ApiConsole
{
    class Program
    {
        static void Main()
        {
            string subscriptionId = ConfigurationManager.AppSettings["subscriptionId"];
            Client client = new Client(subscriptionId, new ConsoleWriter());
            client.GetStorageServices();

            Console.ReadKey();
        }
    }
}
