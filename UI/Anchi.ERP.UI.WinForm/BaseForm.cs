using Anchi.ERP.Domain.Users;
using System;
using System.Windows.Forms;

namespace Anchi.ERP.UI.WinForm
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            //if (CurrentUser == null && this.Name != "LoginForm")
            //{
            //    MessageBox.Show("请先登录。" + this.Name, "温馨提示");

            //    var loginForm = new LoginForm();
            //    if (loginForm.ShowDialog() != DialogResult.OK)
            //    {
            //        Application.Exit();
            //    }
            //}
        }

        /// <summary>
        /// 当前登录用户
        /// </summary>
        public User CurrentUser
        {
            get; set;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "BaseForm";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.ResumeLayout(false);
        }

        protected void ShowSingleWindow(Type type)
        {
            foreach (Form item in this.MdiChildren)
            {
                if (item.GetType() != type)
                    continue;

                item.Activate();
                return;
            }

            var frm = type.Assembly.CreateInstance(type.ToString()) as BaseForm;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.CurrentUser = CurrentUser;
            frm.Show();
        }

        protected void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "错误", MessageBoxButtons.OK);
        }
    }
}
