using Chloe.Infrastructure;
using System.Data;
using System.Data.SQLite;

namespace Anchi.ERP.Data.Chloe
{
    public class AnchiConnectionFactory : IDbConnectionFactory
    {
        string _connString = null;
        public AnchiConnectionFactory(string connString)
        {
            this._connString = connString;
        }

        public IDbConnection CreateConnection()
        {
            return new SQLiteConnection(this._connString);
        }
    }
}
