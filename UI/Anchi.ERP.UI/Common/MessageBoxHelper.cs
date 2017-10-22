using System.Windows;

namespace Anchi.ERP.UI.Common
{
    /// <summary>
    /// 弹框帮助类
    /// </summary>
    public static class MessageBoxHelper
    {
        /// <summary>
        /// 显示错误弹框
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            MessageBox.Show(message, "错误...", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
