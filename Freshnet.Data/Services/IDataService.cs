using System.Collections.Generic;
using Freshnet.Models;
using MongoDB.Bson;

namespace Freshnet.Data.Services
{
    public interface IDataService
    {
        DataServiceCreationResult Create(IDataElement dataElement);
        List<IDataElement> GetAll();
        IDataElement GetById(ObjectId id);
        IDataElement GetByAlias(string alias);
    }
}