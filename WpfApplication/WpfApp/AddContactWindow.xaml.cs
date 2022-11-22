using System.Windows;
using WpfApp.VIewModels;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для AddContactWindow.xaml
    /// </summary>
    public partial class AddContactWindow : Window
    {
        public AddContactWindow()
        {
            InitializeComponent();
            DataContext = new AddWindowViewModel();
        }
    }
}
