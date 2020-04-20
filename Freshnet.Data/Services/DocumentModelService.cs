using System.Collections.Generic;
using Freshnet.Data.Models;
using MongoDB.Bson;

namespace Freshnet.Data.Services
{
    public interface IDocumentModelService : IDataService
    {
    }
    
    public class DocumentModelService : IDocumentModelService
    {
        //use the database client injected here 
        public DataServiceCreationResult Create(IDataElement dataElement)
        {
            DataServiceCreationResult result = new DataServiceCreationResult();
            DocumentModel documentModel = dataElement as DocumentModel;

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
    }
}