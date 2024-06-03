using Azure;
using System.Net;
using Unsplasharp;
using static System.Net.Mime.MediaTypeNames;

namespace WebApi.Client
{
    public class PhotoClient
    {
        string ApiKey = "WTjDTZkVsBox3MRUQ1EGb5tNkg6IYKU8GC499bX2UH4";


        public async Task<string> GetRandomBirdPhoto()
        {
            UnsplasharpClient client=new UnsplasharpClient(ApiKey); 
            var photo =await client.GetRandomPhoto(count:1,query: "bird");
            var url=photo.First().Urls.Regular;
            return url;
        }
        public async Task<string> GetPhoto(string text)
        {
            try
            {
                UnsplasharpClient client = new UnsplasharpClient(ApiKey);
                var photo = await client.GetRandomPhoto(count: 1, query: text);
                var url = photo.First().Urls.Regular;
                return url;
            }
            catch (Exception ex)
            {
                return "error";                 
            }
            
        }
    }
}
