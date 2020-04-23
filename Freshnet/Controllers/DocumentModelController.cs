using System;
using System.Collections.Generic;
using Freshnet.Data.Builders;
using Freshnet.Data.DataTransferObjects;
using Freshnet.Data.Exceptions;
using Freshnet.Data.Models;
using Freshnet.Data.Services;
using Freshnet.Models;
using Microsoft.AspNetCore.Mvc;

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
            if (!ModelState.IsValid)
            {
                //TO DO: Log the invalid request 
                ErrorResponse errorResponse = new ErrorResponse(ModelState);
                return BadRequest(errorResponse.Errors);
            }

            try
            {
                DocumentModel documentModel = DocumentModelBuilder.SetFromDto(data).GetDocumentModel();
                DocumentModelService.Create(documentModel);
                // TO DO: Log the creation of the model 
                return documentModel;
            }
            catch (DocumentException documentException)
            {
                // TO DO log this invalid request
                ErrorResponse errorResponse = new ErrorResponse();
                errorResponse.AppendError(documentException,400);
                return BadRequest(errorResponse);
            }
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
        public ActionResult<List<DocumentModel>> GetAll(string alias)
        {
            List<DocumentModel> models = DocumentModelService.GetAll();
            return models;
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
            // TO DO: Log the updating of the model 
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            // TO DO: Log the deletion of the model 
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            bool deleted = DocumentModelService.Delete(id);
            return deleted ? Ok() : StatusCode(500);
        }
    }
}