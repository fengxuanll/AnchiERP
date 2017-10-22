using Anchi.ERP.Resource;
using Anchi.ERP.Service.Users;
using Anchi.ERP.UI.Common;
using Anchi.ERP.UI.Views;
using System.Security.Principal;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Input;

namespace Anchi.ERP.UI.ViewModels
{
    /// <summary>
    /// 用户登录模型
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region 构造函数
        private UserService UserService { get; set; }
        public LoginViewModel(UserService userService)
        {
            this.UserService = userService;
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
        /// 登录命令
        /// </summary>
        public ICommand LoginCommand
        {
            get
            {
                return new DelegateCommand<PasswordBox>(this.Login);
            }
        }

        /// <summary>
        /// 登录事件
        /// </summary>
        /// <param name="password"></param>
        private void Login(PasswordBox txtPassword)
        {
            this.Password = txtPassword.Password;

            if (string.IsNullOrWhiteSpace(this.LoginName))
            {
                MessageBoxHelper.Error("请输入登录名。");
                return;
            }

            if (string.IsNullOrWhiteSpace(this.Password))
            {
                MessageBoxHelper.Error("请输入密码。");
                return;
            }

            var user = this.UserService.GetModel(this.LoginName, this.Password);
            if (user == null)
            {
                MessageBoxHelper.Error("用户名或密码错误。");
                return;
            }

            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(this.LoginName), null);
            Anchi.ERP.Common.Containers.ApplicationContext.GetContext().SetData(Constants.CurrentUser, user);

            Anchi.ERP.Common.Containers.Container.Instance.ResolveUnity<MainWindow>().Show();
            Anchi.ERP.Common.Containers.Container.Instance.ResolveUnity<LoginWindow>().Close();
        }
        #endregion
    }
}
