using System;
using System.Collections.Generic;
using Freshnet.Data.Builders;
using Freshnet.Data.DataTransferObjects;
using Freshnet.Data.Exceptions;
using Freshnet.Data.Models;
using Freshnet.Data.Services;
using Freshnet.Diagnostics;
using Freshnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace Freshnet.Controllers
{
    [Route("[controller]/[action]")]
    public class DocumentModelController : ControllerBase, IMaintainable<DocumentModel, DocumentModelDto>
    {
        private IDocumentModelBuilder DocumentModelBuilder { get; set; }
        private IDataService<DocumentModel> DocumentModelService { get; set; }

        private ILogger Logger { get; set; }

        public DocumentModelController(IDocumentModelBuilder documentModelBuilder, 
            IDataService<DocumentModel> dataService,
            ILogger logger)
        {
            DocumentModelBuilder = documentModelBuilder;
            DocumentModelService = dataService;
            Logger = logger;
        }

        [HttpPost]
        public ActionResult<DocumentModel> Create([FromBody]DocumentModelDto data)
        {
            if (!ModelState.IsValid)
            {
                ErrorResponse errorResponse = new ErrorResponse(ModelState);
                Logger.Warning(errorResponse);
                return BadRequest(errorResponse.Errors);
            }

            try
            {
                DocumentModel documentModel = DocumentModelBuilder.SetFromDto(data).GetDocumentModel();
                DocumentModelService.Create(documentModel);
                Logger.Info($"[{GetType().Name}] Document model with id ({documentModel.Id}) has been created");
                return documentModel;
            }
            catch (DocumentException documentException)
            {
                Logger.Error(documentException);
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
                ErrorResponse errorResponse = new ErrorResponse();
                errorResponse.AppendError($"Id parameter is required for route {HttpContext.Request.Path}", 403);
                Logger.Warning(errorResponse);
                return BadRequest(errorResponse.Errors);
            }
            
            DocumentModel model = DocumentModelService.GetById(id);
            return model;
        }
        
        [HttpGet]
        public ActionResult<DocumentModel> GetByAlias(string alias)
        {
            if (string.IsNullOrEmpty(alias))
            {
                ErrorResponse errorResponse = new ErrorResponse();
                errorResponse.AppendError($"Alias parameter is required for route {HttpContext.Request.Path}", 403);
                Logger.Warning(errorResponse);
                return BadRequest(errorResponse.Errors);
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
            if (string.IsNullOrEmpty(id))
            {
                ErrorResponse errorResponse = new ErrorResponse();
                errorResponse.AppendError($"Id parameter is required for route {HttpContext.Request.Path}", 403);
                Logger.Warning(errorResponse);
                return BadRequest(errorResponse.Errors);
            }

            bool deleted = DocumentModelService.Delete(id);
            return deleted ? Ok() : StatusCode(500);
        }
    }
}