using System;
using Freshnet.Data.Builders;
using Freshnet.Data.DataTransferObjects;
using Freshnet.Data.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Freshnet.Controllers
{
    [Route("[controller]/[action]")]
    public class DocumentModelController : ControllerBase, IMaintainable<DocumentModel, DocumentModelDto>
    {
        private IDocumentModelBuilder DocumentModelBuilder { get; set; }

        public DocumentModelController(IDocumentModelBuilder documentModelBuilder)
        {
            DocumentModelBuilder = documentModelBuilder;
        }

        [HttpPost]
        public ActionResult<DocumentModel> Create([FromBody]DocumentModelDto obj)
        {
            // TO DO: Validate validity of the model before creating the model 
            DocumentModel documentModel = DocumentModelBuilder.SetValuesFromJson(obj).GetDocumentModel();
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