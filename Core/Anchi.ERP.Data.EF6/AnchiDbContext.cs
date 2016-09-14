using Anchi.ERP.Data.EF6.Map;
using Anchi.ERP.Domain.Users;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Anchi.ERP.Data.EF6
{
    public class AnchiDbContext : DbContext
    {
        public AnchiDbContext() : base("AnchiERP")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add<User>(new UserMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
