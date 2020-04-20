using System;
using System.Collections.Generic;
using Freshnet.Data.DataTransferObjects;
using Freshnet.Data.Models;
using PropertyGroup = Freshnet.Data.Models.PropertyGroup;

namespace Freshnet.Data.Builders
{
    public class DocumentModelBuilder : IDocumentModelBuilder
    {
        public void Reset()
        {
            throw new NotImplementedException();
        }

        public IDocumentModelBuilder SetCreationDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IDocumentModelBuilder SetAlias(string name)
        {
            throw new NotImplementedException();
        }

        public IDocumentModelBuilder SetVersion(int version)
        {
            throw new NotImplementedException();
        }

        public IDocumentModelBuilder SetAuthor(string author)
        {
            throw new NotImplementedException();
        }

        public IDocumentModelBuilder SetProperties(List<PropertyGroup> properties)
        {
            throw new NotImplementedException();
        }

        public IDocumentModelBuilder SetValuesFromJson(DocumentModelDto model)
        {
            throw new NotImplementedException();
        }

        public IDocumentModel GetDocumentModel()
        {
            throw new NotImplementedException();
        }
    }
}