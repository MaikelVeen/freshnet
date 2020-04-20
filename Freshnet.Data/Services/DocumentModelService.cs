using System.Collections.Generic;
using Freshnet.Data.Builders;
using Freshnet.Data.DataTransferObjects;
using Freshnet.Data.Models;
using MongoDB.Bson;

namespace Freshnet.Data.Services
{
    public interface IDocumentModelService : IDataService
    {
    }
    
    public class DocumentModelService : IDocumentModelService
    {
        private IDatabaseClient DatabaseClient { get; set; }
        private IDocumentModelBuilder Builder { get; set; }

        public DocumentModelService(IDatabaseClient databaseClient, IDocumentModelBuilder builder)
        {
            DatabaseClient = databaseClient;
            Builder = builder;

        }

        public IDataElement Create(object documentModelDto)
        {
            DocumentModelDto clientData = documentModelDto as DocumentModelDto;
            return null;
        }
        
        public List<IDataElement> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IDataElement GetById(ObjectId id)
        {
            throw new System.NotImplementedException();
        }

        public IDataElement GetByAlias(string alias)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(ObjectId id)
        {
            throw new System.NotImplementedException();
        }
    }
}