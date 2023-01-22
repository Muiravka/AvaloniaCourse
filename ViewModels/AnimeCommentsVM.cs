using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using coursach.Models.ApiModels;
using coursach.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursach.ViewModels
{
    public class AnimeCommentsVM : ViewModelBase
    {
        public AnimeCommentsVM()
        {
            int id = (int)CurrentAnimeInfo.CurAnime.id;
            _currentAnime = context.GetAnimeInfo(id);
            _pageTitle = CurrentAnime.russian;
            _listOfComments = new ObservableCollection<UserComment>(dbContext.UserComments.Where(x => x.AnimeId == CurrentAnime.id));
        }

        private ShikiApi context = new ShikiApi();
        private CourseContext dbContext = new CourseContext();

        #region Fields

        private Anime? _currentAnime;
        public Anime? CurrentAnime
        {
            get => _currentAnime;
            set => _currentAnime = value;
        }

        private string _pageTitle;
        public string PageTitle
        {
            get => "Комментарии аниме " + _pageTitle;
            set => _pageTitle = value;
        }

        private ObservableCollection<UserComment> _listOfComments;
        public ObservableCollection<UserComment> ListOfComments
        {
            get=> _listOfComments;
            set => _listOfComments = value;
        }

        #endregion

        #region Commands

        public RelayCommand CreateComment
        {
            get => new (() =>
            {
                //...
            });
        }

        public RelayCommand<Window> GoBack
        {
            get => new(x =>
            {
                AnimeInfoPage animeInfoPage = new AnimeInfoPage();
                animeInfoPage.Show();
                x.Close();
            });
        }

        #endregion
    }
}