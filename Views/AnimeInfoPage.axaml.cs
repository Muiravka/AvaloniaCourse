using Avalonia.Controls;
using coursach.ViewModels;

namespace coursach.Views
{
    public partial class AnimeInfoPage : Window
    {
        public AnimeInfoPage(/*int id*/)
        {
            InitializeComponent();
            DataContext = new AnimeInfoPageVM(/*id*/);
        }
    }
}
