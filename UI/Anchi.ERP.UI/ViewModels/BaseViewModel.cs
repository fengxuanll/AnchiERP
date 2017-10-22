using Anchi.ERP.Common.Extensions;
using System.ComponentModel;

namespace Anchi.ERP.UI.ViewModels
{
    /// <summary>
    /// ViewModel基类
    /// </summary>
    public class BaseViewModel :  INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        public void RaisePropertyChange(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.ToJson();
        }
    }
}
