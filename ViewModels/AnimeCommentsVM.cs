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
    public class AnimeCommentsVM : ViewModelBase
    {

        private ShikiApi context = new ShikiApi();
        private CourseContext dbContext = new CourseContext();
        public AnimeCommentsVM()
        {
            int id = (int)CurrentAnimeInfo.CurAnime.id;
            _currentAnime = context.GetAnimeInfo(id);
            _pageTitle = CurrentAnime.russian;
            _listOfComments = new ObservableCollection<UserComment>(dbContext.UserComments.Where(x => x.AnimeId == id));
        }

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
            get => _listOfComments;
            set => _listOfComments = value;
        }

        public string? CommentContentString { get; set; }

        #endregion

        #region Commands

        public RelayCommand CreateComment
        {
            get => new (() =>
            {
                User _user = CurrentUser.currentUser;
                if (_user != null)
                {
                    string comString = CommentContentString;
                    int usrId = _user.Id;
                    int anime_id = (int)CurrentAnimeInfo.CurAnime.id;
                    if (comString != null)
                    {
                        UserComment newUserComment = new UserComment();
                        newUserComment.User = _user;
                        newUserComment.AnimeId = anime_id;
                        newUserComment.Userid = usrId;
                        newUserComment.Commentcontent = comString;
                        dbContext.UserComments.Add(newUserComment);
                        var messageBoxSuccess = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Успех", "Комментарий успешно создан.");
                        messageBoxSuccess.Show();
                        ListOfComments = new ObservableCollection<UserComment>(dbContext.UserComments.Where(x => x.AnimeId == (int)CurrentAnimeInfo.CurAnime.id));
                        OnPropertyChanged();
                    }
                    else if (comString == null)
                    {
                        var messageBoxFail = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", "Комментарий пуст.");
                        messageBoxFail.Show();
                    }
                }
                else if(_user == null)
                {
                    var messageBoxFail = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", "Вы должны авторизоваться.");
                    messageBoxFail.Show();
                }
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