using Freshnet.Data.Models;
using MongoDB.Driver;

namespace Freshnet.Data
{
    public interface IDatabaseClient
    {
        
    }
    
    public class DatabaseClient : IDatabaseClient
    {
        public IDatabaseSettings DatabaseSettings;
        public IMongoDatabase Database { get; set; }
        public MongoClient Client { get; set; }
        
        public DatabaseClient(IDatabaseSettings databaseSettings)
        {
            DatabaseSettings = databaseSettings;
            Client = new MongoClient(databaseSettings.ConnectionString);
            Database = Client.GetDatabase(databaseSettings.DatabaseName);
        }
        
    }
}