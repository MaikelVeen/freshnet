using System;
using Freshnet.Data.Builders;
using Freshnet.Data.DataTransferObjects;
using Freshnet.Data.Models;
using Freshnet.Data.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Freshnet.Controllers
{
    [Route("[controller]/[action]")]
    public class DocumentModelController : ControllerBase, IMaintainable<DocumentModel, DocumentModelDto>
    {
        private IDocumentModelBuilder DocumentModelBuilder { get; set; }
        private IDataService<DocumentModel> DocumentModelService { get; set; }

        public DocumentModelController(IDocumentModelBuilder documentModelBuilder, IDataService<DocumentModel> dataService)
        {
            DocumentModelBuilder = documentModelBuilder;
            DocumentModelService = dataService;
        }

        [HttpPost]
        public ActionResult<DocumentModel> Create([FromBody]DocumentModelDto data)
        {
            // TO DO: Validate validity of the model before creating the model 
            // TO DO: check if build model is not null
            DocumentModel documentModel = DocumentModelBuilder.SetFromDto(data).GetDocumentModel();
            DocumentModelService.Create(documentModel);
            return documentModel;
        }
        
        [HttpGet]
        public ActionResult<DocumentModel> Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            
            DocumentModel model = DocumentModelService.GetById(id);
            return model;
        }
        
        [HttpGet]
        public ActionResult<DocumentModel> GetByAlias(string alias)
        {
            if (string.IsNullOrEmpty(alias))
            {
                return BadRequest();
            }

            DocumentModel model = DocumentModelService.GetByAlias(alias);
            return model;
        }
        
        [HttpGet]
        public ActionResult<DocumentModel> GetAll(string alias)
        {
            throw new NotImplementedException();
        }
        
        [HttpGet]
        public ActionResult<DocumentModel> Overview(string alias)
        {
            // TO DO make overview view model
            throw new NotImplementedException();
        }
        
        [HttpPut]
        public IActionResult Update(DocumentModelDto obj)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            bool deleted = DocumentModelService.Delete(id);
            return deleted ? Ok() : StatusCode(500);
        }
    }
}