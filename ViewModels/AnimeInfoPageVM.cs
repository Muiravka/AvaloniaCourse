using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using coursach.Models.ApiModels;
using coursach.Views;
using coursach.Views.CurrentUser;
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

        #region Fields
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

        #endregion

        #region Commands

        RelayCommand<Window> OpenComments
        {
            get => new(x =>
            {
                AnimeComments comPage = new AnimeComments();
                comPage.Show();
                x.Close();
            });
        }

        RelayCommand<Window> BackToTheMainPage
        {
            get => new(x =>
            {
                if (CurrentUser.currentUser != null)
                {
                    AutorizatedHomePage autorizatedHomePage = new AutorizatedHomePage();
                    autorizatedHomePage.Show();
                    x.Close();
                }
                else
                {
                    MainWindow mainWindow= new MainWindow();
                    mainWindow.Show();
                    x.Close();
                }
            });
        }

        #endregion

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
