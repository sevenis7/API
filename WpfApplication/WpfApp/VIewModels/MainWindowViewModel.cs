using AspApplication.BLL.Interfaces;
using AspApplication.BLL.Service;
using AspApplication.Domain.Entity;
using BaseLib;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace WpfApp.VIewModels
{
    public class MainWindowViewModel : Bindable
    {
        readonly IContactService _contactService;
        readonly IAccountService _accountService;
        readonly string name;
        readonly string role;
        bool addVisibility;
        bool deleteVisibility;
        bool editVisibility;
        bool gridVisibility;
        ObservableCollection<Contact> contacts;
        ObservableCollection<User> users;
        Contact selectedContact;
        User selectedUser;
        RelayCommand add;
        RelayCommand delete;
        RelayCommand edit;
        RelayCommand about;
        RelayCommand deleteUser;

        public bool AddVisibility
        {
            get => addVisibility;
            set
            {
                addVisibility = value;
                OnPropertyChanged(nameof(AddVisibility));
            }
        }

        public bool DeleteVisibility
        {
            get => deleteVisibility;
            set
            {
                deleteVisibility = value;
                OnPropertyChanged(nameof(DeleteVisibility));
            }
        }

        public bool EditVisibility
        {
            get => editVisibility;
            set
            {
                editVisibility = value;
                OnPropertyChanged(nameof(EditVisibility));
            }
        }

        public bool GridVisibility
        {
            get => gridVisibility;
            set
            {
                gridVisibility = value;
                OnPropertyChanged(nameof(GridVisibility));
            }
        }

        public string Name
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    return name;
                }
                return "Неавторизованный пользователь";
            }
        }

        public string Role
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    return role;
                }
                return "Неавторизованный пользователь";
            }
        }

        public ObservableCollection<Contact> Contacts
        {
            get => contacts;
            set
            {
                contacts = value;
                OnPropertyChanged(nameof(Contacts));
            }
        }

        public ObservableCollection<User> Users
        {
            get => users;
            set
            {
                users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public Contact SelectedContact
        {
            get => selectedContact;
            set
            {
                selectedContact = value;
                OnPropertyChanged(nameof(SelectedContact));
            }
        }

        public User SelectedUser
        {
            get => selectedUser;
            set
            {
                selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        public RelayCommand Delete
        {
            get
            {
                return delete ??
                    (delete = new RelayCommand(async e =>
                    {
                        var contact = e as Contact;
                        await _contactService.Delete(contact.Id);
                        Contacts.Remove(contact);
                    }, e =>
                    {
                        return (e as Contact) != null;
                    }));
            }
        }

        public RelayCommand Add
        {
            get
            {
                return add ??
                    (add = new RelayCommand(async e =>
                    {
                        var dlg = new AddContactWindow();
                        if (dlg.ShowDialog() == true)
                        {
                            var contact = new Contact()
                            {
                                LastName = dlg.lastNametxt.Text,
                                FirstName = dlg.firstNametxt.Text,
                                MiddleName = dlg.middleNametxt.Text,
                                PhoneNumber = dlg.phoneNumbertxt.Text,
                                Addres = dlg.addrestxt.Text,
                                Description = dlg.descriptiontxt.Text
                            };
                            await _contactService.Create(contact);
                            UpdateContacts();
                            OnPropertyChanged(nameof(Contacts));
                        }
                    }));
            }
        }

        public RelayCommand About
        {
            get
            {
                return about ?? (about = new RelayCommand(e =>
                {
                    var dlg = new AboutWindow(e as Contact);
                    dlg.ShowDialog();
                },e =>
                {
                    return (e as Contact) != null;
                }));
            }
        }

        public RelayCommand Edit
        {
            get
            {
                return edit ?? (edit = new RelayCommand(e =>
                {
                    var dlg = new EditContactWindow(e as Contact);
                    var id = (e as Contact).Id;
                    if (dlg.ShowDialog() == true)
                    {
                        var contact = new Contact()
                        {
                            LastName = dlg.lastNametxt.Text,
                            FirstName = dlg.firstNametxt.Text,
                            MiddleName = dlg.middleNametxt.Text,
                            PhoneNumber = dlg.phoneNumbertxt.Text,
                            Addres = dlg.addrestxt.Text,
                            Description = dlg.descriptiontxt.Text
                        };
                        _contactService.Edit(id, contact);
                        UpdateContacts();
                    }
                }, e =>
                {
                    return (e as Contact) != null;
                }));
            }
        }

        public RelayCommand DeleteUser
        {
            get
            {
                return deleteUser ??
                    (deleteUser = new RelayCommand(async e =>
                    {
                        var user = e as User;
                        var userName = user.UserName;
                        await _accountService.Delete(userName);
                        Users.Remove(user);

                    }, e =>
                    {
                        return (e as User) != null;
                    }));
            }
        }

        private void UpdateContacts()
        {
            contacts = new ObservableCollection<Contact>(_contactService.GetAll().Result);
        }

        public MainWindowViewModel(IAccountService accountService, string token)
        {
            _accountService = accountService;
            _contactService = new WPFService(token);
            if (!string.IsNullOrWhiteSpace(token))
            {
                var jwt = new JwtSecurityToken(token);
                name = jwt.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
                role = jwt.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
                if (role == AspApplication.Domain.Entity.Role.User.ToString())
                {
                    addVisibility = true;
                }
                if (role == AspApplication.Domain.Entity.Role.Admin.ToString())
                {
                    addVisibility = true;
                    deleteVisibility = true;
                    editVisibility = true;
                    gridVisibility = true;
                    users = new ObservableCollection<User>(_accountService.GetAllUsers().Result);
                }
            }
            contacts = new ObservableCollection<Contact>(_contactService.GetAll().Result);
        }
    }
}
