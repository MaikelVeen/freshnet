using System;
using System.Collections.Generic;
using Freshnet.Data.DataTransferObjects;
using Freshnet.Data.Models;
using PropertyGroup = Freshnet.Data.Models.PropertyGroup;

namespace Freshnet.Data.Builders
{
    public interface IDocumentModelBuilder
    {
        void Reset();
        IDocumentModelBuilder SetUpdateDate(DateTime date);
        IDocumentModelBuilder SetAlias(string name);
        IDocumentModelBuilder SetVersion(int version);
        IDocumentModelBuilder SetAuthor(string author);
        IDocumentModelBuilder SetProperties(List<PropertyGroup> properties);
        IDocumentModelBuilder SetFromDto(DocumentModelDto model);
        DocumentModel GetDocumentModel();
    }
}