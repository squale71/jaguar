using System.Linq;
using System.Threading.Tasks;
using Jaguar.Abstractions;
using Jaguar.Data.Models;
using MongoDB.Driver;

namespace Jaguar.Data.Repositories
{
    public class LeagueMongoRepository : ILeagueDbRepository
    {
        private readonly IMongoDatabase _context;

        public LeagueMongoRepository(MongoDbConnection connection)
        {
            _context = connection.Context;
        }

        public async Task AddLeague(League league)
        {
            var collection = _context.GetCollection<League>("leagues");

            await collection.InsertOneAsync(league);
        }

        public async Task<League> GetLeague(int year, ulong id)
        {
            var collection = _context.GetCollection<League>("leagues");
            var theLeague = new League();

            var filter = Builders<League>.Filter.Or(
                Builders<League>.Filter.Where(p => p.Id == id),
                Builders<League>.Filter.Where(p => p.Year == year));

            return await collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
