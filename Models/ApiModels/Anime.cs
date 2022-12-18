using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace coursach.Models.ApiModels
{
    public class Anime
    {
        //example:
        //"id": 1,
        //"name": "Cowboy Bebop",
        //"russian": "Ковбой Бибоп",
        //"image": {
        //    "original": "/system/animes/original/1.jpg?1633690032",
        //    "preview": "/system/animes/preview/1.jpg?1633690032",
        //    "x96": "/system/animes/x96/1.jpg?1633690032",
        //    "x48": "/system/animes/x48/1.jpg?1633690032"
        //},
        //"url": "/animes/1-cowboy-bebop",
        //"kind": "tv"

        [JsonProperty ("id")] public int? id { get; set; } //id аниме
        [JsonProperty ("name")] public string? name { get; set; } //название на английском языке
        [JsonProperty ("russian")] public string? russian { get; set; } //название на русском языке
        [JsonProperty ("description")] public string? description { get; set; } //описание аниме на русском
        [JsonProperty("status")] public string? status { get; set; } // состояние выхода серий: вышел/выходит/анонсирован
        [JsonProperty ("aired_on")] public string? aired_on { get; set; } //дата выхода в эфир
        [JsonProperty ("kind")] public string? kind { get; set; } //тип: сериал, полнометражный, короткометражный
        [JsonProperty ("score")] public string? score { get; set; } // средняя оценка произведения по 10-ти балльной шкале оценивания
        [JsonProperty("episodes")] public int? episodes { get; set; } // количество вышедших эпизодов
        [JsonProperty("image")] public Images? image { get; set; } // постер аниме в двух размерах

        public class Images
        {
            private string? original;
            [JsonPropertyName("original")]
            public string Original 
            {
                get => $"https://shikimori.one{original}";
                set => original = value; 
            }

            private string? preview;
            [JsonPropertyName("preview")]
            public string Preview 
            { 
                get => $"https://shikimori.one{preview}"; 
                set => preview = value; 
            }
        }
    }
}
