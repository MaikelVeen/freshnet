using System.Collections.Generic;
using Freshnet.Data.Models;
using MongoDB.Bson;

namespace Freshnet.Data.Services
{
    public interface IDataService
    {
        IDataElement Create(object dataTransferObject);
        List<IDataElement> GetAll();
        IDataElement GetById(ObjectId id);
        IDataElement GetByAlias(string alias);
        bool Delete(ObjectId id);
    }
}