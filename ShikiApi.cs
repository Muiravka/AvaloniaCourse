using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using coursach.Models.ApiModels;
//using RestSharp.Serialization.Json;
//using Newtonsoft.Json;

namespace coursach
{
    public class ShikiApi
    {
        private HttpClient httpClient;

        public ShikiApi()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://shikimori.one/");
        }

        public CurrentAnimeInfo GetAnimeInfo(int id)
        {
            CurrentAnimeInfo animeInfo = new CurrentAnimeInfo();

            string param = $"api/animes/{id}";
            HttpResponseMessage response = httpClient.GetAsync(param).Result;

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                animeInfo = JsonSerializer.Deserialize<CurrentAnimeInfo>(json);
            }

            return animeInfo;
        }

        //example: https://shikimori.one/api/animes/?page=1&order=popularity&limit=10&search=Naruto
        public List<Anime> GetAnimeList(int page = 1, string? SearchString = null)
        {
            List<Anime>? listOfAnime = new List<Anime>();

            string param = $"api/animes/?page={page}&order=popularity&limit=10";
            if (SearchString != null)
            {
                param += $"&search={SearchString}";
            }

            HttpResponseMessage response = httpClient.GetAsync(param).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                listOfAnime = JsonSerializer.Deserialize<List<Anime>>(json);
            }

            return listOfAnime;
        }
    }
}
