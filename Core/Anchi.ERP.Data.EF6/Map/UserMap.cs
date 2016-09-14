using Anchi.ERP.Domain.Users;
using System.Data.Entity.ModelConfiguration;

namespace Anchi.ERP.Data.EF6.Map
{
    public class UserMap: EntityTypeConfiguration<User>
    {
        public UserMap()
        {

        }
    }
}
