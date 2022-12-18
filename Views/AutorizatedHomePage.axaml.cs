using Avalonia.Controls;
using coursach.ViewModels;

namespace coursach.Views
{
    public partial class AutorizatedHomePage : Window
    {
        public AutorizatedHomePage()
        {
            InitializeComponent();
            DataContext = new AutorizatedHomePageVM();
        }
    }
}
