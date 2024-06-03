using apiweb.Model;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Web;

namespace apiweb.Client
{
    public class ObservationsClient
    {
        string ApiKey = "vj3fomr1fk96";

        public async Task<string> GetObservforaRegionCode(string regionCode)
        {

            string path = $"https://api.ebird.org/v2/data/obs/{regionCode}/recent?back=1&maxResults=24";

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(path),//address            
                Headers =
                {
                    { "X-eBirdApiToken",ApiKey},
                },

            };
            using (var response = await client.SendAsync(request))
            {
                if (!response.IsSuccessStatusCode)
                {
                    return "error";
                    
                }

                var body = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ObservationsInfo[]>(body);

                if (result.Length == 0)
                {
                    return "Здається, в цьому регіоні не спостерігалось птахів сьогодні і вчора...";
                }
                string ListOfObserv = "";
                foreach (var responseItem in result)
                {
                    ListOfObserv = ListOfObserv + "\nНазва: " + responseItem.sciName + ".\nЗвичайна назва: " + responseItem.comName+ ".\nМiсце,в якому спостерігалось: " + responseItem.locName + "\nДата: " + responseItem.obsDt + "\nКількість: " + responseItem.howMany + "\n ";

                }
                return ListOfObserv;
            }
        }
   
    }
}