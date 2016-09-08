using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;

namespace Anchi.ERP.Common.Logging.Log4net
{
    /// <summary>
    /// 日志类
    /// </summary>
    public class LogManager
    {
        private static Dictionary<string, ILog> LogDict = new Dictionary<string, ILog>();
        /// <summary>
        /// 日志文件路径
        /// </summary>
        public static string LogConfigPath
        {
            get; set;
        }
        /// <summary>
        /// 通用日志
        /// </summary>
        public static ILog CommonLoger
        {
            get;
            private set;
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        public static ILog ErrorLoger
        {
            get;
            private set;
        }

        static LogManager()
        {
            if (string.IsNullOrWhiteSpace(LogConfigPath))
            {
                LogConfigPath = AppDomain.CurrentDomain.BaseDirectory + "Config/log4net.config";
                if (!File.Exists(LogConfigPath))
                    LogConfigPath = AppDomain.CurrentDomain.BaseDirectory + "bin/Config/log4net.config";
            }

            if (File.Exists(LogConfigPath))
            {
                var fileInfo = new FileInfo(LogConfigPath);
                XmlConfigurator.ConfigureAndWatch(fileInfo);
            }

            CommonLoger = GetLogger("CommonLog");
            ErrorLoger = GetLogger("ErrorLog");
        }

        /// <summary>
        /// 获取指定名称的日志记录器。
        /// </summary>
        /// <param name="name">日志记录器名称</param>
        /// <returns></returns>
        public static ILog GetLogger(string name)
        {
            if (!LogDict.ContainsKey(name))
                LogDict[name] = log4net.LogManager.GetLogger(name);

            return LogDict[name];
        }
    }
}
