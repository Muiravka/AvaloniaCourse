using Avalonia.Controls;
using coursach.ViewModels;

namespace coursach.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new HomePageVM();
        }
    }
}