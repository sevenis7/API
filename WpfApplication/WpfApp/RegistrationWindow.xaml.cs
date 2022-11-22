using System.Windows;
using WpfApp.VIewModels;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            DataContext = new RegistrationWindowViewModel();
        }
    }
}
