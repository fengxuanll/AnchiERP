using Chloe.Infrastructure;
using System.Data;
using System.Data.SQLite;

namespace Anchi.ERP.Repository
{
    /// <summary>
    /// 数据库工厂类
    /// </summary>
    public class AnchiDbFactory: IDbConnectionFactory
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private string ConnectionString
        { get; }

        public AnchiDbFactory(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        /// <summary>
        /// 创建连接
        /// </summary>
        /// <returns></returns>
        public IDbConnection CreateConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }
    }
}
