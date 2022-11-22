using AspApplication.Domain.Entity;
using System.Windows;
using WpfApp.VIewModels;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow(Contact contact)
        {
            InitializeComponent();
            DataContext = new AboutWindowViewModel(contact);
        }
    }
}
