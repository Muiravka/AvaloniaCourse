using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursach.ViewModels
{
    public class AnimeInfoPageVM : ViewModelBase
    {
        private ShikiApi context = new ShikiApi();
        private CurrentAnimeInfo? currentAnime;
        public CurrentAnimeInfo CurrentAnime
        {
            get => currentAnime;
        }
        public AnimeInfoPageVM(int id) 
        {
            currentAnime = context.GetAnimeInfo(id);
        }
    }
}
