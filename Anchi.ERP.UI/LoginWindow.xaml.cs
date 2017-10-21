using Anchi.ERP.UI.ViewModels;
using System.Windows;

namespace Anchi.ERP.UI
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        private LoginViewModel viewModel = null;
        public LoginWindow()
        {
            this.InitializeComponent();

            this.viewModel = new LoginViewModel();
            this.DataContext = this.viewModel;
        }

        #region 登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            this.viewModel.LoginName = txtLoginName.Text;
            this.viewModel.Password = txtPassword.Password;
            this.viewModel.LoginCommand.Execute(null);

            var mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }
        #endregion
    }
}
