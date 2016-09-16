using Anchi.ERP.Common.Configuration;
using Chloe.Infrastructure;
using Chloe.SQLite;

namespace Anchi.ERP.Repository
{
    /// <summary>
    /// 安驰数据库上下文
    /// </summary>
    public class AnchiDbContext : SQLiteContext
    {
        public AnchiDbContext() : this(ConnectionStringReader.GetConnectionString("AnchiERP")) { }

        public AnchiDbContext(string connectionString) : this(new AnchiDbFactory(connectionString))
        { }

        public AnchiDbContext(IDbConnectionFactory dbFactory) : base(dbFactory)
        { }
    }
}
