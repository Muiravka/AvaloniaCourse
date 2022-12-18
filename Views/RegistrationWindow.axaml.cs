using Avalonia.Controls;
using coursach.ViewModels;

namespace coursach.Views
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();

            DataContext = new RegistrationVM();
        }
    }
}
