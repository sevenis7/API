using BaseLib;
using System.Windows;

namespace WpfApp.VIewModels
{
    public class AddWindowViewModel : Bindable
    {
        CloseDialogCommand add;
        CloseDialogCommand cancel;

        public CloseDialogCommand Add
        {
            get
            {
                return add ??
                    (add = new CloseDialogCommand(e =>
                    {
                        (e as Window).DialogResult = true;
                    }, e =>
                    {
                        return !string.IsNullOrWhiteSpace((e as AddContactWindow).firstNametxt.Text) &&
                        !string.IsNullOrWhiteSpace((e as AddContactWindow).lastNametxt.Text) &&
                        !string.IsNullOrWhiteSpace((e as AddContactWindow).middleNametxt.Text) &&
                        !string.IsNullOrWhiteSpace((e as AddContactWindow).phoneNumbertxt.Text);
                    }));
            }
        }

        public CloseDialogCommand Cancel
        {
            get
            {
                return cancel ??
                    (cancel = new CloseDialogCommand(e =>
                    {
                        (e as Window).DialogResult = false;
                    }));
            }
        }
    }
}
