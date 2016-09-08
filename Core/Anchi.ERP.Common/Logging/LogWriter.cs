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
        /// <param name="format"></param>
        /// <param name="arg0"></param>
        public static void InfoFormat(string format, params object[] arg0)
        {
            LogManager.CommonLoger.InfoFormat(format, arg0);
        }

        /// <summary>
        /// 写错误日志
        /// </summary>
        /// <param name="format"></param>
        /// <param name="arg0"></param>
        public static void ErrorFormat(string format, params object[] arg0)
        {
            LogManager.ErrorLoger.ErrorFormat(format, arg0);
        }
    }
}
