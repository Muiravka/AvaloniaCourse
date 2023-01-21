using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShikimoriSharp.Information;
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

        [JsonProperty("id")] public int? id { get; set; } //id аниме
        [JsonProperty("name")] public string? name { get; set; } //название на английском языке
        [JsonProperty("russian")] public string? russian { get; set; } //название на русском языке
        [JsonProperty("description")] public string? description { get; set; } //описание аниме на русском
        [JsonProperty("status")] private string? _status; // состояние выхода серий
        public string? status
        {
            get
            {
                if (_status == "released")
                {
                    return "Полностью вышло.";
                }
                else if (_status == "ongoing")
                {
                    return "Выходит.";
                }
                else return _status;
            } 
            set => _status = value; 
        } 
        [JsonProperty("aired_on")] public string? aired_on { get; set; } //дата выхода в эфир
        [JsonProperty("kind")] public string? kind { get; set; } //тип: сериал, полнометражный, короткометражный
        [JsonProperty("score")] public string? score { get; set; } // средняя оценка произведения по 10-ти балльной шкале оценивания
        [JsonProperty("episodes")] public int? episodes { get; set; } // количество эпизодов
        [JsonProperty("episodes_aired")] public int? episodes_aired { get; set; } // количество вышедших эпизодов
        [JsonProperty("image")] public Images? image { get; set; } // постеры аниме
        [JsonProperty("rating")] private string? _rating; // возрастной рейтинг
        public string rating
        {
            get
            {
                if (_rating == "r")
                {
                    return "R-17. Лицам до 17 лет обязательно присутствие взрослого.";
                }
                else if (_rating == "r_plus")
                {
                    return "R+. Лмцам до 17 лет просмотр запрещён.";
                }
                else if (_rating == "pg_13")
                {
                    return "PG-13. Детям до 13 лет просмотр не желателен.";
                }
                else if (_rating == "pg")
                {
                    return "PG. Рекомендуется присутствие родителей.";
                }
                else if (_rating == "rx")
                {
                    return "Rx. Хентай.";
                }
                else return _rating;
            }
            set => _rating = value;
        }

        [JsonProperty("duration")] public int? duration { get; set; } // длительность эпизода
        [JsonProperty("genres")] public Genres[]? genres { get; set; } // список жанров
        //[JsonProperty("studios")] public Studios? studios { get; set; } // студия

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

            private string? _x96;
            [JsonPropertyName("x96")]
            public string x96
            {
                get => $"https://shikimori.one{_x96}";
                set => _x96 = value;
            }
        }

        public class Genres
        {
            [JsonPropertyName("id")] public int Id { get; set; }

            [JsonPropertyName("russian")] public string? Russian { get; set; }
        }


    }
}
