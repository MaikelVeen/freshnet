using System.Collections.Generic;
using System.Linq;
using Freshnet.Data.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Freshnet.Data.Services
{
    public class DocumentModelService : IDataService<DocumentModel>
    {
        private DatabaseClient DatabaseClient { get; set; }
        private IMongoCollection<DocumentModel> DocumentModels { get; set; }

        public DocumentModelService(IDatabaseClient databaseClient)
        {
            DatabaseClient = (DatabaseClient) databaseClient;
            DocumentModels =
                DatabaseClient.Database.GetCollection<DocumentModel>(DatabaseClient.DatabaseSettings
                    .DocumentModelCollection);
        }
        
        public DocumentModel Create(DocumentModel model)
        {
            // TO DO check if alias already exists 
            DocumentModels.InsertOne(model);
            return model;
        }

        List<DocumentModel> IDataService<DocumentModel>.GetAll()
        {
            throw new System.NotImplementedException();
        }

        DocumentModel IDataService<DocumentModel>.GetById(string id)
        {
            FilterDefinition<DocumentModel> filter = Builders<DocumentModel>.Filter.Eq("_id", ObjectId.Parse(id));
            return DocumentModels.Find(filter).ToList().FirstOrDefault();
        }

        DocumentModel IDataService<DocumentModel>.GetByAlias(string alias)
        {
            FilterDefinition<DocumentModel> filter = Builders<DocumentModel>.Filter.Eq(document => document.Alias, alias);
            return DocumentModels.Find(filter).ToList().FirstOrDefault();
        }

        public bool Delete(string id)
        {
            FilterDefinition<DocumentModel> filter = Builders<DocumentModel>.Filter.Eq("_id", ObjectId.Parse(id));
            DeleteResult deleteResult = DocumentModels.DeleteOne(filter);
            return deleteResult.IsAcknowledged;
        }
    }
}