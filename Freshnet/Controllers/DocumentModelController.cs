using System;
using Freshnet.Data.DataTransferObjects;
using Freshnet.Data.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Freshnet.Controllers
{
    [Route("[controller]/[action]")]
    public class DocumentModelController : ControllerBase, IMaintainable<DocumentModel, DocumentModelDto>
    {
        [HttpPost]
        public ActionResult<DocumentModel> Create([FromBody]DocumentModelDto obj)
        {
            DocumentModel documentModel = new DocumentModel();
            documentModel.Name = "Test";
            return documentModel;
        }
        
        [HttpGet]
        public ActionResult<DocumentModel> Retrieve(ObjectId key)
        {
            throw new NotImplementedException();
        }
        
        [HttpPut]
        public IActionResult Update(DocumentModelDto obj)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IActionResult Delete(ObjectId key)
        {
            throw new NotImplementedException();
        }
    }
}