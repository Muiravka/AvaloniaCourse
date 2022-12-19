using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
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
    public class AutorizatedHomePageVM : ViewModelBase
    {
        private ShikiApi context = new ShikiApi();

        public AutorizatedHomePageVM()
        {
            _animes = new ObservableCollection<Anime>(context.GetAnimeList());
        }

        #region Fields
        private string? _searchString;
        public string SearchString
        {
            get => _searchString;
            set
            {
                _searchString = value;
                OnPropertyChanged(nameof(SearchString));
            }
        }

        private ObservableCollection<Anime>? _animes;
        public ObservableCollection<Anime> Animes
        {
            get => _animes;
            set
            {
                _animes = value;
                OnPropertyChanged();
            }
        }

        private int _page = 1;
        public int Page
        {
            get => _page;
            set
            {
                _page = value;
                OnPropertyChanged();
            }
        }

        #endregion


        #region Commands
        public RelayCommand<Window> ReturnToProfile
        {
            get => new(x =>
            {
                var prof = new Profile();
                prof.Show();
                x.Close();
            });
        }
        public RelayCommand KeyEnterSearch
        {
            get => new(() =>
            {
                Animes = new ObservableCollection<Anime>(context.GetAnimeList(Page, SearchString));
            });
        }

        #endregion
    }
}
