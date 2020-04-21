using System.Collections.Generic;
using Freshnet.Data.Models;
using MongoDB.Bson;

namespace Freshnet.Data.Services
{
    public interface IDataService<T>
    {
        T Create(T model);
        List<T> GetAll();
        T GetById(ObjectId id);
        T GetByAlias(string alias);
        bool Delete(ObjectId id);
    }
}