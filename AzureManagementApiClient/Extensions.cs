using System.IO;
using System.Net;
using System.Xml.Serialization;

namespace AzureManagementApiClient
{
    public static class Extensions
    {
        public static T DeserializeContent<T>(this HttpWebResponse response)  where T : class
        {
            var xs = new XmlSerializer(typeof(T), Constants.AzureNamespace);
            using (var rd = new StreamReader(response.GetResponseStream()))
            {
                return xs.Deserialize(rd) as T;
            }
        }
    }
}