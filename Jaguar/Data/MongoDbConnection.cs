using Discord_Bot_Application.App_Start;
using MongoDB.Driver;

namespace Jaguar.Data
{
    public class MongoDbConnection : DbConnection
    {
        private MongoClient _client;

        public IMongoDatabase Context { get; }

        public MongoDbConnection()
        {
            _client = new MongoClient(Configuration.Instance.GetBySection("ConnectionStrings", "MongoDB"));
            Context = _client.GetDatabase("Jaguar");
        }

        // Doesn't actually have any way to dispose, but keeping this here for now.
        public override void Dispose()
        {
        }
    }
}
