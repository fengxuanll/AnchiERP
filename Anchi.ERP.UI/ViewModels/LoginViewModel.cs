using System;
using System.Windows;

namespace Anchi.ERP.UI.ViewModels
{
    /// <summary>
    /// 用户登录模型
    /// </summary>
    public class LoginViewModel : NotifyObject
    {
        #region 构造函数
        public DelegateCommand LoginCommand { get; set; }
        public LoginViewModel()
        {
            this.LoginName = "admin";
            this.LoginCommand = new DelegateCommand(this.Login);
        }
        #endregion

        #region 属性
        private string _loginName;
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName
        {
            get => this._loginName;
            set
            {
                this._loginName = value;
                this.RaisePropertyChange(nameof(this.LoginName));
            }
        }

        private string _password;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get => this._password;
            set
            {
                this._password = value;
                this.RaisePropertyChange(nameof(this.Password));
            }
        }
        #endregion

        #region 事件
        /// <summary>
        /// 登录事件
        /// </summary>
        /// <param name="parameter"></param>
        private void Login(object parameter)
        {
            throw new Exception("xx");
            MessageBox.Show(this.LoginName + " " + this.Password);
        }
        #endregion
    }
}
