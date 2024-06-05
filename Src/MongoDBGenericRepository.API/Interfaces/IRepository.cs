using MongoDBGenericRepository.API.Models;

namespace MongoDBGenericRepository.API.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> FindAsync(Guid id);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(Guid id, TEntity entity);
        Task RemoveAsync(Guid id);
    }
}
