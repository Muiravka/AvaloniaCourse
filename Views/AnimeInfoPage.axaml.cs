using Avalonia.Controls;
using coursach.ViewModels;

namespace coursach.Views
{
    public partial class AnimeInfoPage : Window
    {
        public AnimeInfoPage()
        {
            InitializeComponent();
            DataContext = new AnimeInfoPageVM();
        }
    }
}
