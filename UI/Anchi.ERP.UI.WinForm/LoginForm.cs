using Anchi.ERP.Domain.Users.Enum;
using Anchi.ERP.Service.Users;
using System;
using System.Windows.Forms;

namespace Anchi.ERP.UI.WinForm
{
    public partial class LoginForm : BaseForm
    {
        public LoginForm() : this(new UserService())
        {

        }

        public LoginForm(UserService userService)
        {
            InitializeComponent();
            this.UserService = userService;
        }

        UserService UserService
        {
            get;
        }

        #region 登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            var loginName = txtLoginName.Text.Trim();
            if (string.IsNullOrWhiteSpace(loginName))
            {
                ShowErrorMessage("请输入登录名。");
                return;
            }
            var passWord = txtPassword.Text.Trim();
            if (string.IsNullOrWhiteSpace(passWord))
            {
                ShowErrorMessage("请输入密码。");
                return;
            }
            var model = this.UserService.GetModel(loginName, passWord);
            if (model == null)
            {
                ShowErrorMessage("用户名或密码错误。");
                return;
            }
            if (model.Status != EnumUserStatus.Normal)
            {
                ShowErrorMessage("用户非正常状态，请联系管理员。");
                return;
            }

            this.CurrentUser = model;
            this.DialogResult = DialogResult.OK;
        }
        #endregion
    }
}
