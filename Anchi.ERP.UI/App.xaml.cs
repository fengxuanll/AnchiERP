using Anchi.ERP.Common.Logging;
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
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            LogWriter.ErrorFormat($"未捕捉的异常：{e.Exception}");
            MessageBox.Show(e.Exception.Message, "崩溃了......", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
