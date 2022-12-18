using coursach.Models.ApiModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursach
{
    public class CurrentAnimeInfo : Anime
    {
        [JsonProperty("name")] public string? EnglishName { get; set; } //название на английском языке
        [JsonProperty("russian")] public string? RussianName { get; set; } //название на русском языке
        [JsonProperty("description")] public string? Description { get; set; } //описание аниме на русском
        [JsonProperty("status")] public string? Status { get; set; } // состояние выхода серий: вышел/выходит/анонсирован
        [JsonProperty("aired_on")] public string? AiredOn { get; set; } //дата выхода в эфир
        [JsonProperty("kind")] public string? Kind { get; set; } //тип: сериал, полнометражный, короткометражный
        [JsonProperty("score")] public string? Score { get; set; } // средняя оценка произведения по 10-ти балльной шкале оценивания
        [JsonProperty("episodes")] public int? Episodes { get; set; } // количество вышедших эпизодов
        [JsonProperty("image")] public Images[]? AnimeImage { get; set; } // постер аниме в двух размерах

        public class AnimeImages
        {
            private string? _original;
            private string? _preview;

            [JsonProperty("original")]
            public string Original
            {
                get => $"https://shikimori.one{_original}";
                set => this._original = value;
            }
            [JsonProperty("preview")]
            public string Preview
            {
                get => $"https://shikimori.one{_preview}";
                set => this._preview = value;
            }
        }
    }
}
