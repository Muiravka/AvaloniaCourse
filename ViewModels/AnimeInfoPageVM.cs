using coursach.Models.ApiModels;
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
        private Anime? _currentAnime;
        public Anime? CurrentAnime
        {
            get => _currentAnime;
            set => _currentAnime = value;
        }

        private List<string> _listOfGenres;
        public List<string> ListOfGenres
        {
            get => _listOfGenres;
            set => _listOfGenres = value;
        }

        public AnimeInfoPageVM()
        {
            int id = (int)CurrentAnimeInfo.CurAnime.id;
            _currentAnime = context.GetAnimeInfo(id);
            _listOfGenres = new List<string>();
            foreach (var item in CurrentAnime.genres)
            {
                _listOfGenres.Add(item.Russian);
            }
        }
    }
}
