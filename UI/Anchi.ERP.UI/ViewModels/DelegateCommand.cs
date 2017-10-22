using System;
using System.Windows.Input;

namespace Anchi.ERP.UI.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class DelegateCommand : ICommand
    {
        private Action ExecuteAction = null;
        private Func<bool> CanExecuteFunc = null;
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="canExecute"></param>
        public DelegateCommand(Action action, Func<bool> canExecute = null)
        {
            this.ExecuteAction = action;
            this.CanExecuteFunc = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (this.CanExecuteFunc != null)
                return this.CanExecuteFunc();

            return true;
        }

        public void Execute(object parameter)
        {
            this.ExecuteAction?.Invoke();
        }

        /// <summary>
        /// 
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DelegateCommand<T> : ICommand
    {
        private Action<T> ExecuteAction = null;
        private Func<T, bool> CanExecuteFunc = null;
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="canExecute"></param>
        public DelegateCommand(Action<T> action, Func<T, bool> canExecute = null)
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
                return this.CanExecuteFunc((T)parameter);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            this.ExecuteAction?.Invoke((T)parameter);
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
