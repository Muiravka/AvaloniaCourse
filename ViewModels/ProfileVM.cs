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
    public class ProfileVM
    {
        public ProfileVM() 
        {

        }

        public string Name
        {
            get => CurrentUser.currentUser.Nickname;
        }

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
    }
}
