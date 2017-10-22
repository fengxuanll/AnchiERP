using System;
using System.Windows.Input;

namespace Anchi.ERP.UI.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class DelegateCommand : ICommand
    {
        private Action<object> ExecuteAction = null;
        private Func<object, bool> CanExecuteFunc = null;
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="canExecute"></param>
        public DelegateCommand(Action<object> action, Func<object, bool> canExecute = null)
        {
            this.ExecuteAction = action;
            this.CanExecuteFunc = canExecute;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            if (this.CanExecuteFunc != null)
                return this.CanExecuteFunc(parameter);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            this.ExecuteAction?.Invoke(parameter);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
