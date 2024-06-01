using System.Net;
using Unsplasharp;
using static System.Net.Mime.MediaTypeNames;

namespace WebApi.Client
{
    public class PhotoClient
    {
        string ApiKey = "WTjDTZkVsBox3MRUQ1EGb5tNkg6IYKU8GC499bX2UH4";


        public async Task<string> GetRandomPhoto()
        {
            UnsplasharpClient client=new UnsplasharpClient(ApiKey); 
            var photo =await client.GetRandomPhoto(count:1,query: "bird");
            var url=photo.First().Urls.Regular;
            return url;
        }
      
        public async Task<string> GetRandomBirdPhoto()
        {
            string path = $"https://api.unsplash.com/photos?query=Bird&per_page=1&client_id={ApiKey}";

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

            return " ";
        }

    }
}
