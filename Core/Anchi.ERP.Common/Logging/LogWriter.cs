using Anchi.ERP.Common.Logging.Log4net;

namespace Anchi.ERP.Common.Logging
{
    /// <summary>
    /// 写日志
    /// </summary>
    public class LogWriter
    {
        /// <summary>
        /// 写普通日志
        /// </summary>
        /// <param name="message"></param>
        public static void Info(object message)
        {
            LogerManager.CommonLoger.Info(message);
        }

        /// <summary>
        /// 写普通日志
        /// </summary>
        /// <param name="format"></param>
        /// <param name="arg0"></param>
        public static void InfoFormat(string format, params object[] arg0)
        {
            LogerManager.CommonLoger.InfoFormat(format, arg0);
        }

        /// <summary>
        /// 写错误日志
        /// </summary>
        /// <param name="message"></param>
        public static void Error(object message)
        {
            LogerManager.ErrorLoger.Error(message);
        }

        /// <summary>
        /// 写错误日志
        /// </summary>
        /// <param name="format"></param>
        /// <param name="arg0"></param>
        public static void ErrorFormat(string format, params object[] arg0)
        {
            LogerManager.ErrorLoger.ErrorFormat(format, arg0);
        }
    }
}
