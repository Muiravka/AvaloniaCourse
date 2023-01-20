using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using MessageBox.Avalonia.DTO;
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

        private CurrentAnimeInfo? currentAnime;
        public CurrentAnimeInfo CurrentAnime
        {
            get => currentAnime;
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

        private Anime? _selectedAnime;
        public Anime? SelectedAnime
        {
            get => _selectedAnime;
            set => _selectedAnime = value;
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

        public RelayCommand PlusPage
        {
            get => new(() =>
            {
                Page++;
                OnPropertyChanged(nameof(Animes));
            });
        }

        public RelayCommand MinusPage
        {
            get => new(() =>
            {
                Page--;
                OnPropertyChanged(nameof(Animes));
            });
        }

        public RelayCommand<Anime> OpenAnimePage
        {
            get => new(obj =>
            {

                if (obj != null)
                {
                    int id = Convert.ToInt32(obj.id);
                    CurrentAnimeInfo.CurAnime = obj;//context.GetAnimeInfo(id);
                    AnimeInfoPage animePage = new AnimeInfoPage(/*id*/);
                    animePage.Show();
                }
                else
                {
                    var messageBoxNoData = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", "Нет выбранного аниме.");
                    messageBoxNoData.Show();
                }
            });
        }
        #endregion
    }
}