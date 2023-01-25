using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using coursach.Models;
using coursach.Models.ApiModels;
using coursach.Views;
using coursach.Views.CurrentUser;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursach.ViewModels
{
    public class AnimeInfoPageVM : ViewModelBase
    {
        private CourseContext DbContext = new CourseContext();
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


        public RelayCommand<Window> OpenComments
        {
            get => new(x =>
            {
                AnimeComments comPage = new AnimeComments();
                comPage.Show();
                x.Close();
            });
        }

        public RelayCommand<Window> BackToTheMainPage
        {
            get => new(x =>
            {
                if (CurrentUser.currentUser != null)
                {
                    //AutorizatedHomePage autorizatedHomePage = new AutorizatedHomePage();
                    //autorizatedHomePage.Show();
                    x.Close();
                }
                else
                {
                    //MainWindow mainWindow= new MainWindow();
                    //mainWindow.Show();
                    x.Close();
                }
            });
        }

        public RelayCommand AddToDropList
        {
            get => new(() =>
            {
                if (CurrentUser.currentUser != null)
                {
                    int animeId = (int)CurrentAnimeInfo.CurAnime.id;
                    int userId = (int)CurrentUser.currentUser.Id;
                    var existingCheck1 = DbContext.Droppedanimes.FirstOrDefault(x => x.Animeid == animeId && x.Userid == userId);
                    var existingCheck2 = DbContext.Watchedanimes.FirstOrDefault(x => x.Animeid == animeId && x.Userid == userId);
                    var existingCheck3 = DbContext.Plantowatches.FirstOrDefault(x => x.Animeid == animeId && x.Userid == userId);
                    if (existingCheck1 == null && existingCheck2 == null && existingCheck3 == null)
                    {
                        Droppedanime droppedanime = new Droppedanime();
                        droppedanime.Animeid = animeId;
                        droppedanime.Userid = userId;
                        DbContext.Droppedanimes.Add(droppedanime);
                        DbContext.SaveChanges();
                        var messageBoxSuccess = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Успех", "Вы успешно добавили аниме в список.");
                        messageBoxSuccess.Show();
                    }
                    else
                    {
                        var messageBoxFail = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", "Вы уже добавили это аниме в список.");
                        messageBoxFail.Show();
                    }
                }
                else
                {
                    var messageBoxFail = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", "Войдите в аккаунт.");
                    messageBoxFail.Show();
                }
            });
        }

        public RelayCommand AddToPlanList
        {
            get => new(() =>
            {
                if (CurrentUser.currentUser != null)
                {
                    int animeId = (int)CurrentAnimeInfo.CurAnime.id;
                    int userId = (int)CurrentUser.currentUser.Id;
                    var existingCheck1 = DbContext.Droppedanimes.FirstOrDefault(x => x.Animeid == animeId && x.Userid == userId);
                    var existingCheck2 = DbContext.Watchedanimes.FirstOrDefault(x => x.Animeid == animeId && x.Userid == userId);
                    var existingCheck3 = DbContext.Plantowatches.FirstOrDefault(x => x.Animeid == animeId && x.Userid == userId);
                    if (existingCheck1 == null && existingCheck2 == null && existingCheck3 == null)
                    {
                        Plantowatch plantowatch = new Plantowatch();
                        plantowatch.Animeid = animeId;
                        plantowatch.Userid = userId;
                        DbContext.Plantowatches.Add(plantowatch);
                        DbContext.SaveChanges();
                        var messageBoxSuccess = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Успех", "Вы успешно добавили аниме в список.");
                        messageBoxSuccess.Show();
                    }
                    else
                    {
                        var messageBoxFail = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", "Вы уже добавили это аниме в список.");
                        messageBoxFail.Show();
                    }
                }
                else
                {
                    var messageBoxFail = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", "Войдите в аккаунт.");
                    messageBoxFail.Show();
                }
            });
        }

        public RelayCommand AddToWatchedList
        {
            get => new(() =>
            {
                if (CurrentUser.currentUser != null)
                {
                    int animeId = (int)CurrentAnimeInfo.CurAnime.id;
                    int userId = (int)CurrentUser.currentUser.Id;
                    var existingCheck1 = DbContext.Droppedanimes.FirstOrDefault(x => x.Animeid == animeId && x.Userid == userId);
                    var existingCheck2 = DbContext.Watchedanimes.FirstOrDefault(x => x.Animeid == animeId && x.Userid == userId);
                    var existingCheck3 = DbContext.Plantowatches.FirstOrDefault(x => x.Animeid == animeId && x.Userid == userId);
                    if (existingCheck1 == null && existingCheck2 == null && existingCheck3 == null)
                    {
                        Watchedanime watchedanime = new Watchedanime();
                        watchedanime.Animeid = animeId;
                        watchedanime.Userid = userId;
                        DbContext.Watchedanimes.Add(watchedanime);
                        DbContext.SaveChanges();
                        var messageBoxSuccess = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Успех", "Вы успешно добавили аниме в список.");
                        messageBoxSuccess.Show();
                    }
                    else
                    {
                        var messageBoxFail = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", "Вы уже добавили это аниме в список.");
                        messageBoxFail.Show();
                    }
                }
                else
                {
                    var messageBoxFail = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", "Войдите в аккаунт.");
                    messageBoxFail.Show();
                }
            });
        }

        public RelayCommand DeleteFromAllLists
        {
            get => new(() =>
            {
                if (CurrentUser.currentUser != null)
                {
                    int animeId = (int)CurrentAnimeInfo.CurAnime.id;
                    int userId = (int)CurrentUser.currentUser.Id;
                    var existingCheck1 = DbContext.Droppedanimes.FirstOrDefault(x => x.Animeid == animeId && x.Userid == userId);
                    var existingCheck2 = DbContext.Watchedanimes.FirstOrDefault(x => x.Animeid == animeId && x.Userid == userId);
                    var existingCheck3 = DbContext.Plantowatches.FirstOrDefault(x => x.Animeid == animeId && x.Userid == userId);
                    if (existingCheck1 != null)
                    {
                        DbContext.Droppedanimes.Remove(existingCheck1);
                        DbContext.SaveChanges();
                        var messageBoxSuccess = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Успех", "Вы успешно удалили аниме из списка.");
                        messageBoxSuccess.Show();
                    }
                    else if (existingCheck2 != null)
                    {
                        DbContext.Watchedanimes.Remove(existingCheck2);
                        DbContext.SaveChanges();
                        var messageBoxSuccess = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Успех", "Вы успешно удалили аниме из списка.");
                        messageBoxSuccess.Show();
                    }
                    else if (existingCheck3 != null)
                    {
                        DbContext.Plantowatches.Remove(existingCheck3);
                        DbContext.SaveChanges();
                        var messageBoxSuccess = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Успех", "Вы успешно удалили аниме из списка.");
                        messageBoxSuccess.Show();
                    }
                    else
                    {
                        var messageBoxFail = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", "Аниме нет в списке.");
                        messageBoxFail.Show();
                    }
                }
                else
                {
                    var messageBoxFail = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", "Войдите в аккаунт.");
                    messageBoxFail.Show();
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
