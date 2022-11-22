using AspApplication.Domain.Entity;
using BaseLib;
using System.Windows;

namespace WpfApp.VIewModels
{
    public class AboutWindowViewModel : Bindable
    {
        Contact contact;
        CloseDialogCommand close;

        public Contact Contact
        {
            get => contact;
            set
            {
                contact = value;
                OnPropertyChanged(nameof(Contact));
            }
        }

        public CloseDialogCommand Close
        {
            get
            {
                return close ?? (close = new CloseDialogCommand(e =>
                {
                    (e as Window).DialogResult = false;
                }));
            }
        }

        public AboutWindowViewModel(Contact contact)
        {
            Contact = contact;
        }

    }
}
