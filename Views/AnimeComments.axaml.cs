using Avalonia.Controls;
using coursach.ViewModels;

namespace coursach.Views
{
    public partial class AnimeComments : Window
    {
        public AnimeComments()
        {
            InitializeComponent();
            DataContext = new AnimeCommentsVM();
        }
    }
}
