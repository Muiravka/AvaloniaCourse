using Avalonia.Controls;
using coursach.ViewModels;

namespace coursach.Views
{
    public partial class AutorizationWindow : Window
    {
        public AutorizationWindow()
        {
            InitializeComponent();
            DataContext= new AutorizationVM();
        }
    }
}
