using MongoDB.Driver;
using MongoDBGenericRepository.API.Interfaces;
using MongoDBGenericRepository.API.Models;

namespace Olivitec.Lifestyle.Shared.Framework.Repositories.MongoDB
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly IMongoCollection<TEntity> _collection;

        public Repository(IConfiguration configuration, string collection)
        {
            var mongoClient = new MongoClient(configuration["MongoDB:ConnectionString"]);

            var mongoDatabase = mongoClient.GetDatabase(configuration["MongoDB:Database"]);

            _collection = mongoDatabase.GetCollection<TEntity>(collection);
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<TEntity> FindAsync(Guid id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(Guid id, TEntity entity)
        {
            await _collection.ReplaceOneAsync(x => x.Id == id, entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
