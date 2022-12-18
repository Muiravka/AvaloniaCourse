using Avalonia;
using CommunityToolkit.Mvvm.Input;
using coursach.Views;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using MessageBox.Avalonia.DTO;
using coursach.Models;

namespace coursach.ViewModels
{
    public class RegistrationVM : ViewModelBase
    {
        public RegistrationVM()
        {

        }

        #region Fields
        public string? UserLogin { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }

        
        #endregion

        #region Commands
        public RelayCommand<Window> RegistrationAccept
        {
            get => new(x =>
            {
                if (UserLogin == null || UserEmail == null || UserPassword == null)
                {
                    var messageBoxNoData = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", "Недостаток данных.");
                    messageBoxNoData.Show();
                }
                else if (true)
                {
                    CourseContext context = new CourseContext();
                    var existingUser = context.Users.FirstOrDefault(x => x.Nickname == UserLogin);
                    if (existingUser != null)
                    {
                        var messageBoxUserExists = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", "Такой пользователь уже существует.");
                        messageBoxUserExists.Show();
                    }
                    else if (UserLogin != null && UserEmail != null && UserPassword != null && existingUser == null)
                    {
                        User newUser = new User();
                        newUser.Nickname = UserLogin;
                        newUser.Email = UserEmail;
                        newUser.UserPassword = UserPassword;
                        context.Add(newUser);
                        context.SaveChanges();
                        var messageBoxSuccess = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Успех", "Пользователь успешно зарегистрирован.");
                        messageBoxSuccess.Show();
                        var home = new MainWindow();
                        home.Show();
                        x.Close();
                    }
                }
            });
        }

        public RelayCommand<Window> RegistrationCancel
        {
            get => new(x =>
            {
                var home = new MainWindow();
                home.Show();
                x.Close();
            });
        }

        #endregion
    }
}
