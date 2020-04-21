using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Freshnet.Controllers
{
    /// <summary>
    /// Interface that an controller that creates CRUD
    /// functionality should implement
    /// </summary>
    /// <typeparam name="T">The model</typeparam>
    /// <typeparam name="T1">Data transfer object</typeparam>
    public interface IMaintainable<T,T1>
    {
        ActionResult<T> Create(T1 obj);
        ActionResult<T> Get(string id);
        IActionResult Update(T1 obj);
        IActionResult Delete(string id);
    }
}