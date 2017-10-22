using Anchi.ERP.UI.ViewModels;

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
    }
}
