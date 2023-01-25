using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using coursach.Models;
using coursach.Models.ApiModels;
using coursach.Views;
using coursach.Views.CurrentUser;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursach.ViewModels
{
    public class ProfileVM
    {
        #region Context

        private ShikiApi ShikiContext = new ShikiApi();
        private CourseContext DbContext = new CourseContext();
        public ProfileVM()
        {
            int id = (int)CurrentUser.currentUser.Id;
            _droppedAnimes = new ObservableCollection<Droppedanime>(DbContext.Droppedanimes.Where(x => x.Userid == id));
            _watchedAnimes = new ObservableCollection<Watchedanime>(DbContext.Watchedanimes.Where(x => x.Userid == id));
            _plantowatch = new ObservableCollection<Plantowatch>(DbContext.Plantowatches.Where(x => x.Userid == id));

            _droppedAnime = new ObservableCollection<Anime>();
            _watchedAnime = new ObservableCollection<Anime>();
            _planToWatchAnime = new ObservableCollection<Anime>();

            foreach (var drop in _droppedAnimes)
            {
                int animeId = drop.Animeid;
                Anime _droppedAnime_ = ShikiContext.GetAnimeInfo(animeId);
                _droppedAnime.Add(_droppedAnime_);
            }

            foreach (var watched in _watchedAnimes)
            {
                int animeId = watched.Animeid;
                Anime _watchedAnime_ = ShikiContext.GetAnimeInfo(animeId);
                _watchedAnime.Add(_watchedAnime_);
            }

            foreach (var plan in _plantowatch)
            {
                int animeId = plan.Animeid;
                Anime _planToWatch_ = ShikiContext.GetAnimeInfo(animeId);
                _planToWatchAnime.Add(_planToWatch_);
            }

        }
        #endregion

        #region Fields

        private Anime? _selectedAnime;
        public Anime? SelectedAnime
        {
            get => _selectedAnime;
            set => _selectedAnime = value;
        }

        private ObservableCollection<Droppedanime> _droppedAnimes;
        private ObservableCollection<Watchedanime> _watchedAnimes;
        private ObservableCollection<Plantowatch> _plantowatch;

        private ObservableCollection<Anime> _droppedAnime;
        private ObservableCollection<Anime> _watchedAnime;
        private ObservableCollection<Anime> _planToWatchAnime;
        public ObservableCollection<Anime> DroppedAnime { get => _droppedAnime; set => _droppedAnime = value; }
        public ObservableCollection<Anime> WatchedAnime { get => _watchedAnime; set => _droppedAnime = value; }
        public ObservableCollection<Anime> PlanToWatchAnime { get => _planToWatchAnime; set => _planToWatchAnime = value; }


        public string Name
        {
            get => CurrentUser.currentUser.Nickname;
        }

        #endregion

        #region Commands
        public RelayCommand<Window> ReturnToHome
        {
            get => new(x =>
            {
                var home = new AutorizatedHomePage();
                home.Show();
                x.Close();
            });
        }

        public RelayCommand<Window> LogOut
        {
            get => new(x =>
            {
                CurrentUser.currentUser = null;
                var home = new MainWindow();
                home.Show();
                x.Close();
            });
        }

        #endregion
    }
}
