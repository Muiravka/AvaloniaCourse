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
        private static Anime? _curAnime;
        public static Anime? CurAnime { get => _curAnime; set => _curAnime = value; }
    }
}
