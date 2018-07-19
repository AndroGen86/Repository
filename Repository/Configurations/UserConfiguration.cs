using System.Data.Entity.ModelConfiguration;
using Repository.Entities;

namespace Repository.Configurations
{
    public class UserConfiguration: EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("User");
            HasKey(x => x.Id);
            HasMany(x => x.Addresses).WithRequired().HasForeignKey(y => y.UserId);
        }
    }
}
