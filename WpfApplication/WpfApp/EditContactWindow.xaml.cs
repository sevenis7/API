using AspApplication.Domain.Entity;
using System.Windows;
using WpfApp.VIewModels;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для EditContactWindow.xaml
    /// </summary>
    public partial class EditContactWindow : Window
    {
        public EditContactWindow(Contact contact)
        {
            InitializeComponent();
            DataContext = new EditContactWindowViewModel(contact);
        }
    }
}
