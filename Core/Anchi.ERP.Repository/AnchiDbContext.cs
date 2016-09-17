using Anchi.ERP.Common.Configuration;
using ServiceStack.OrmLite;
using System.Data;

namespace Anchi.ERP.Repository
{
    /// <summary>
    /// 安驰数据库上下文
    /// </summary>
    public class AnchiDbContext : OrmLiteConnectionFactory
    {
        public AnchiDbContext() : this(ConnectionStringReader.GetConnectionString("AnchiERP")) { }

        public AnchiDbContext(string connectionString) : base(connectionString, SqliteDialect.Provider)
        {
            
        }
    }
}
