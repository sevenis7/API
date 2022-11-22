using AspApplication.BLL.Interfaces;
using System.Windows;
using WpfApp.VIewModels;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IAccountService accountService, string token)
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(accountService, token);
        }
    }
}
