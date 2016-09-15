using Anchi.ERP.Common.Configuration;
using SqliteSugar;

namespace Anchi.ERP.Data.Repository
{
    /// <summary>
    /// 安驰数据库上下文
    /// </summary>
    public class AnchiDbContext : SqlSugarClient
    {
        public AnchiDbContext() : this(ConnectionStringReader.GetConnectionString("AnchiERP")) { }

        public AnchiDbContext(string connectionString) : base(connectionString)
        {
        }
    }
}
