using System.Threading.Tasks;

namespace Repository
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        void Save();
        Task SaveAsync();
    }
}
