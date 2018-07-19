using System.Data.Entity;
using Repository.Configurations;

namespace Repository
{
    public class RepoDbContext : DbContext
    {
        public RepoDbContext(string connectionStr) : base(connectionStr)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
        }
    }
}
