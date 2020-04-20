using MongoDB.Driver;

namespace Freshnet.Data
{
    public interface IDatabaseClient
    {
        
    }
    
    public class DatabaseClient : IDatabaseClient
    {
        private readonly IDatabaseSettings _databaseSettings;
        public IMongoDatabase Database { get; set; }
        public MongoClient Client { get; set; }

        public DatabaseClient(IDatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
            Client = new MongoClient(databaseSettings.ConnectionString);
            Database = Client.GetDatabase(databaseSettings.DatabaseName);
        }
        
    }
}