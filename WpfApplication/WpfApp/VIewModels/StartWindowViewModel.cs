using AspApplication.BLL.Interfaces;
using AspApplication.BLL.Service;
using AspApplication.Domain.ViewModels;
using BaseLib;
using System.Reflection;

namespace WpfApp.VIewModels
{
    public class StartWindowViewModel : Bindable
    {
        readonly IAccountService accountService;
        RelayCommand login;
        RelayCommand unauthorized;
        RelayCommand registration;

        public RelayCommand Login
        {
            get => login ??
                (login = new RelayCommand(async e =>
                {
                    var userName = (e as StartWindow).userNametxt.Text;
                    var password = (e as StartWindow).passwordtxt.Text;
                    var user = new UserLogin() { UserName = userName, Password = password };
                    var token = accountService.Login(user).Result;
                    if (!string.IsNullOrWhiteSpace(token))
                    {
                        var window = new MainWindow(accountService, token);
                        (e as StartWindow).Close();
                        window.Show();
                    }
                }));

        }

        public RelayCommand Unauthorized
        {
            get => unauthorized ??
                (unauthorized = new RelayCommand(async e =>
                {
                    var window = new MainWindow(accountService, "");
                    (e as StartWindow).Close();
                    window.Show();
                }));
        }

        public RelayCommand Registration
        {
            get => registration ??
                (registration = new RelayCommand(async e =>
                {
                    var window = new RegistrationWindow();
                    (e as StartWindow).Close();
                    window.Show();
                }));
        }

        public StartWindowViewModel()
        {
            accountService = new WPFAccountService();
        }
    }
}
