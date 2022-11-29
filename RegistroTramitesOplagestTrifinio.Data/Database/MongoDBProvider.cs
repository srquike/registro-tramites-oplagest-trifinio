using MongoDB.Driver;

namespace RegistroTramitesOplagestTrifinio.Data.Database
{
    public class MongoDBProvider<T> where T : class
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;

        public MongoDBProvider(string connectionString, string databaseName)
        {
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(databaseName);
        }

        public IMongoCollection<T> GetMongoCollection(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}