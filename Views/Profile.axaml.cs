using Avalonia.Controls;
using coursach.ViewModels;

namespace coursach.Views
{
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
            DataContext = new ProfileVM();
        }
    }
}
