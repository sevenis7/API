using System;
using System.Windows.Input;
using System.Windows;

namespace BaseLib
{
    public class CloseDialogCommand : ICommand
    {
        Func<object, bool> canExecute;
        Action<object> execute;

        public bool DialogResult { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public CloseDialogCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return (canExecute == null || canExecute(parameter)) && parameter is Window;
        }
        public void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;
            execute(parameter);
            (parameter as Window).Close();
        }
    }
}
