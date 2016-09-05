using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anchi.ERP.UI.WinForm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var loginForm = new LoginForm();
            var result = loginForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                var mainForm = new MainForm();
                mainForm.CurrentUser = loginForm.CurrentUser;
                Application.Run(mainForm);
            }
        }
    }
}
