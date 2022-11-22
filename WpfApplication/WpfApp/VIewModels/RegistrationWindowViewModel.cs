using AspApplication.BLL.Interfaces;
using AspApplication.BLL.Service;
using AspApplication.Domain.Entity;
using AspApplication.Domain.ViewModels;
using BaseLib;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp.VIewModels
{
    public class RegistrationWindowViewModel : Bindable
    {
        readonly IAccountService _accountService;
        RelayCommand _registrationCommand;
        RelayCommand _cancelCommand;


        public RelayCommand RegistrationCommand
        {
            get
            {
                return _registrationCommand ??
                (_registrationCommand = new RelayCommand(async e =>
                {
                    var window = e as RegistrationWindow;
                    var userName = window.userNametxt.Text;
                    var password = window.passbox.Password;
                    var confirmPasswod = window.confirmPassbox.Password;
                    var roles = new List<RadioButton>() { window.admin, window.user };
                    string role = roles.First(x => x.IsChecked == true).Content.ToString();
                    var user = new UserRegistration()
                    {
                        UserName = userName,
                        Password = password,
                        ConfirmPassword = confirmPasswod,
                        Role = role
                    };
                    using (var client = new HttpClient())
                    {
                        await _accountService.Register(user);
                    }
                    var startWindow = new StartWindow();
                    startWindow.Show();
                    window.Close();
                }, e =>
                {
                    var window = e as RegistrationWindow;
                    return (window.userNametxt.Text != null &&
                    window.passbox.Password != null &&
                    window.passbox.Password == window.confirmPassbox.Password &&
                    (window.admin.IsChecked == true || window.user.IsChecked == true));

                }));
            }
        }

        public RelayCommand CancelCommand
        {
            get
            {
                return _cancelCommand ??
                    (_cancelCommand = new RelayCommand(e =>
                    {
                        var startWindow = new StartWindow();
                        (e as Window).Close();
                        startWindow.Show();
                    }));
            }
        }

        public RegistrationWindowViewModel()
        {
            _accountService = new WPFAccountService();
        }
    }
}
