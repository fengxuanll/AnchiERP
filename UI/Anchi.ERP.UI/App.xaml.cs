using Anchi.ERP.Common.Logging;
using Anchi.ERP.UI.Common;
using Anchi.ERP.UI.Views;
using System.Windows;
using System.Windows.Threading;

namespace Anchi.ERP.UI
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            this.DispatcherUnhandledException += this.App_DispatcherUnhandledException;

            Anchi.ERP.Common.Containers.Container.Instance.ResolveUnity<LoginWindow>().Show();
        }

        /// <summary>
        /// 处理未捕获的异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            LogWriter.ErrorFormat($"未捕捉的异常：{e.Exception}");
            MessageBoxHelper.Error(e.Exception.Message);
        }
    }
}
