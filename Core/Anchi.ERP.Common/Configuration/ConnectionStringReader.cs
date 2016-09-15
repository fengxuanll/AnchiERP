using System.Collections.Generic;
using System.Configuration;
using Anchi.ERP.Common.Extensions;

namespace Anchi.ERP.Common.Configuration
{
    /// <summary>
    /// 配置连接字符串读取器
    /// </summary>
    public class ConnectionStringReader
    {
        private static IDictionary<string, object> Dict;
        static ConnectionStringReader()
        {
            Dict = new Dictionary<string, object>();
        }

        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string connectionName)
        {
            if (string.IsNullOrWhiteSpace(connectionName))
                return string.Empty;

            if (!Dict.ContainsKey(connectionName))
                Dict[connectionName] = ConfigurationManager.ConnectionStrings[connectionName];

            return Dict[connectionName].ExtToString();
        }
    }
}
