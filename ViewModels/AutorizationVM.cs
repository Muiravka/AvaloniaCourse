using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using coursach.Views;
using coursach.Views.CurrentUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursach.ViewModels
{
    public class AutorizationVM : ViewModelBase
    {
        public string? UserLogin { get; set; }
        public string? UserPassword { get; set; }

        public RelayCommand<Window> AutorizationAccept
        {
            get => new(x =>
            {
                if (UserLogin != null && UserPassword != null)
                {
                    CourseContext context = new CourseContext();
                    var user = context.Users.SingleOrDefault(x => x.UserPassword == UserPassword && x.Nickname == UserLogin);
                    if (user != null)
                    {
                        context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        CurrentUser.currentUser = user;
                        context.SaveChanges();
                        var userProfile = new Profile();
                        userProfile.Show();
                        x.Close();
                    }
                    else
                    {
                        var messageBoxNotSuccess = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", "Неверно имя или пароль.");
                        messageBoxNotSuccess.Show();
                    }
                }
                else
                {
                    var messageBoxNotSuccess = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", "Недостаток данных.");
                    messageBoxNotSuccess.Show();
                }
            });
        }

        public RelayCommand<Window> AutorizationCancel
        {
            get => new(x =>
            {
                var home = new MainWindow();
                home.Show();
                x.Close();
            });
        }
    }
}
