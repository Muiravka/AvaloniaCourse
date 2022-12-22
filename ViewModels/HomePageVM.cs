using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using coursach.Models.ApiModels;
using coursach.Views;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;

namespace coursach.ViewModels
{
    public class HomePageVM : ViewModelBase
    {
        private ShikiApi context = new ShikiApi();
        public HomePageVM()
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
        public RelayCommand<Window> RegistrationCommand
        {
            get => new(x =>
            {
                var Registration_Window = new RegistrationWindow();
                Registration_Window.Show();
                x.Close();
            });
        }

        public RelayCommand<Window> AutorizationCommand
        {
            get => new(x =>
            {
                var Autorization_Window = new AutorizationWindow();
                Autorization_Window.Show();
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

        public RelayCommand<Object> OpenAnimePage
        {
            get => new(obj =>
            {
                int id = Convert.ToInt32(obj);
                AnimeInfoPage animePage = new AnimeInfoPage(id);
                animePage.Show();
            });
        }
        #endregion
    }
}