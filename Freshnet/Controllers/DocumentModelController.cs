using System;
using Freshnet.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Freshnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentModelController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(DocumentModel documentModel)
        {
            throw new NotImplementedException();
        }
    }
}