using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursach
{
    public static class ApiMethods
    {
         public static object GetAnimeInfoById (int id)
        {
            var client = new RestClient($"https://shikimori.one/api/animes/{id}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            return response.Content;
        }

        public static object GetTopAnimeList()
        {
            var client = new RestClient("https://shikimori.one/api/animes/?order=popularity&limit=35");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            return response.Content;
        }

        public static object GetAnimeListBySearch(string SearchString)
        {
            var client = new RestClient($"https://shikimori.one/api/animes/?search={SearchString}&limit=35");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            return response.Content;
        }

        public static object GetAnimeImageById(int id)
        {
            var client = new RestClient("https://shikimori.one/system/animes/original/1.jpg");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            return response.Content;
        }
    }
}
