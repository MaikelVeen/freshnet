using System.Collections.Generic;
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
            DocumentModels.InsertOne(model);
            return model;
        }

        List<DocumentModel> IDataService<DocumentModel>.GetAll()
        {
            throw new System.NotImplementedException();
        }

        DocumentModel IDataService<DocumentModel>.GetById(ObjectId id)
        {
            throw new System.NotImplementedException();
        }

        DocumentModel IDataService<DocumentModel>.GetByAlias(string alias)
        {
            throw new System.NotImplementedException();
        }
        
        public bool Delete(ObjectId id)
        {
            throw new System.NotImplementedException();
        }
    }
}