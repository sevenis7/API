using AspApplication.Domain.Entity;
using BaseLib;
using System.Windows;

namespace WpfApp.VIewModels
{
    public class EditContactWindowViewModel : Bindable
    {
        Contact contact;
        CloseDialogCommand save;
        CloseDialogCommand cancel;

        public CloseDialogCommand Save
        {
            get
            {
                return save ?? (save = new CloseDialogCommand(e =>
                {
                    (e as Window).DialogResult = true;
                }, e =>
                {
                    return !string.IsNullOrWhiteSpace((e as EditContactWindow).firstNametxt.Text) &&
                        !string.IsNullOrWhiteSpace((e as EditContactWindow).lastNametxt.Text) &&
                        !string.IsNullOrWhiteSpace((e as EditContactWindow).middleNametxt.Text) &&
                        !string.IsNullOrWhiteSpace((e as EditContactWindow).phoneNumbertxt.Text);
                }));
            }
        }

        public CloseDialogCommand Cancel
        {
            get
            {
                return cancel ?? (cancel = new CloseDialogCommand(e =>
                {
                    (e as Window).DialogResult = false;
                }));
            }
        }

        public Contact Contact
        {
            get => contact;
            set
            {
                contact = value;
                OnPropertyChanged(nameof(Contact));
            }
        }

        public EditContactWindowViewModel(Contact contact)
        {
            Contact = contact;
        }
    }
}
