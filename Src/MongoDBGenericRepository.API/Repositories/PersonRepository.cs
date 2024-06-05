using MongoDBGenericRepository.API.Interfaces;
using MongoDBGenericRepository.API.Models;
using Olivitec.Lifestyle.Shared.Framework.Repositories.MongoDB;

namespace MongoDBGenericRepository.API.Repositories
{
    public class PersonRepository(IConfiguration configuration)
        : Repository<Person>(configuration, COLLECTION), IPersonRepository
    {
        private const string COLLECTION = "persons";
    }
}
