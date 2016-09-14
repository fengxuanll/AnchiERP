using SQLite.CodeFirst;
using System.Data.Entity;

namespace Anchi.ERP.Data.EF6
{
    public class AnchiDbInitializer : SqliteDropCreateDatabaseAlways<AnchiDbContext>
    {
        public AnchiDbInitializer(DbModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public override void InitializeDatabase(AnchiDbContext context)
        {
            base.InitializeDatabase(context);
        }

        protected override void Seed(AnchiDbContext context)
        {
            base.Seed(context);
        }
    }
}
