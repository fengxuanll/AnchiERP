using Anchi.ERP.Common.Logging;
using Anchi.ERP.UI.Common;
using Anchi.ERP.UI.ViewModels;
using System;
using System.Security.Principal;
using System.Threading;
using System.Windows;

namespace Anchi.ERP.UI.Views
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow
    {
        public LoginWindow(LoginViewModel viewModel)
        {
            this.InitializeComponent();

            this.txtLoginName.Focus();
            this.DataContext = viewModel;
        }

        #region 登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = this.DataContext as LoginViewModel;
            viewModel.Password = this.txtPassword.Password;

            try
            {
            }
            catch (Exception ex)
            {
                LogWriter.Error($"用户登录失败，内容：{viewModel}，异常：{ex}");
                MessageBoxHelper.Error($"登录失败：\n\n{ex.Message}");
                return;
            }

            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(viewModel.LoginName), null);
            Anchi.ERP.Common.Containers.ApplicationContext.GetContext().SetData("User", viewModel.LoginName);
            Anchi.ERP.Common.Containers.Container.Instance.ResolveUnity<MainWindow>().Show();
            this.Close();
        }
        #endregion
    }
}
