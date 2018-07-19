using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Repository.Repositories;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        private IUserRepository _userRepository;
        public IUserRepository UserRepository  => _userRepository ?? (_userRepository = new UserRepository(_dbContext));

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            Type entityType = typeof(TEntity);
            Type repositoryType = typeof(Repository<>);

            return (IRepository<TEntity>) Activator.CreateInstance(repositoryType.MakeGenericType(entityType), _dbContext);
        }

        public void Save()
        {
            //we can implement some custom logic here
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            //we can implement some custom logic here
            await _dbContext.SaveChangesAsync();
        }
    }
}
