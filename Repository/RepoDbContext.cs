using System.Data.Entity;
using Repository.Configurations;
using Repository.Entities;

namespace Repository
{
    public class RepoDbContext : DbContext
    {
        public DbSet<User> Users;

        public RepoDbContext(string connectionStr) : base(connectionStr)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new AddressConfiguration());
        }
    }
}
