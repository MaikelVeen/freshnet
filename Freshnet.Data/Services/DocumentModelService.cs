using System.Collections.Generic;
using System.Linq;
using Freshnet.Data.Exceptions;
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
            if (this.GetByAlias(model.Alias) != null)
            {
                throw new DocumentException($"Document model with alias {model.Alias} already exists.");
            }
            
            DocumentModels.InsertOne(model);
            return model;
        }

        public List<DocumentModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public DocumentModel GetById(string id)
        {
            FilterDefinition<DocumentModel> filter = Builders<DocumentModel>.Filter.Eq("_id", ObjectId.Parse(id));
            return DocumentModels.Find(filter).ToList().FirstOrDefault();
        }

        public DocumentModel GetByAlias(string alias)
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