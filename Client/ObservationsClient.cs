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
                    return "Щось пішло не так...Ви допустили помилку в записі команди, або такого регіону не занесено до доступної нам бази даних." +
                 "\n Спробуйте ще раз (p.s приклад команди для корректного пошуку спостережень в Києвській обсласті: /observUA-30)";
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
                    ListOfObserv = ListOfObserv + "\nНазва: " + responseItem.sciName + ".\nМiсце,в якому спостерігалось: " + responseItem.locName + "\nДата: " + responseItem.obsDt + "\nКількість: " + responseItem.howMany + "\n ";

                }
                return ListOfObserv;
            }
        }

        public async Task<string> SpeciesListforaRegion(string RegionCode)
        {
            string path = $"https://api.ebird.org/v2/product/spplist/{RegionCode}";
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
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body.Replace(",", "\n");
            }
        }

        public async Task<string> SpeciesInfoBySpeciesCode(string SpeciesCode)
        {

            string path = $"https://api.ebird.org/v2/ref/taxonomy/ebird?species=hottea1&version=2019";
            var client = new HttpClient();
            path = path.Replace("hottea1", SpeciesCode);
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
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }
    }
}