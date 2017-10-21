using System;
using System.Windows.Input;

namespace Anchi.ERP.UI.ViewModels
{
    public class DelegateCommand : ICommand
    {
        private Action<object> ExecuteAction = null;
        private Func<object, bool> CanExecuteFunc = null;
        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> action, Func<object, bool> canExecute = null)
        {
            this.ExecuteAction = action;
            this.CanExecuteFunc = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (this.CanExecuteFunc != null)
                return this.CanExecuteFunc(parameter);

            return true;
        }

        public void Execute(object parameter)
        {
            this.ExecuteAction?.Invoke(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
