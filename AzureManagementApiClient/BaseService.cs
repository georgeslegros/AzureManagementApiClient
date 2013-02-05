using System.Net;
using System.Xml;
using System.Xml.Linq;

namespace AzureManagementApiClient
{
    public abstract class BaseService
    {
        protected XDocument ExecuteRequest(HttpWebRequest request, out HttpStatusCode statusCode)
        {
            XDocument responseBody = null;
            var response = ExecuteRequest(request);
            statusCode = response.StatusCode;
            if (response.ContentLength > 0)
            {
                using (XmlReader reader = XmlReader.Create(response.GetResponseStream()))
                {
                    responseBody = XDocument.Load(reader);
                }
            }
            response.Close();
          
            return responseBody;
        }

        protected HttpWebResponse ExecuteRequest(HttpWebRequest request)
        {
            HttpWebResponse response;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                // GetResponse throws a WebException for 400 and 500 status codes
                response = (HttpWebResponse)ex.Response;
            }

            return response;
        }
    }
}