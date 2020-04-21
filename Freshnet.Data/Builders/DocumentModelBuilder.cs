using System;
using System.Collections.Generic;
using System.Linq;
using Freshnet.Data.DataTransferObjects;
using Freshnet.Data.Models;
using Freshnet.Data.Utilities;
using PropertyGroup = Freshnet.Data.Models.PropertyGroup;
using Property = Freshnet.Data.Models.Property;

namespace Freshnet.Data.Builders
{
    public class DocumentModelBuilder : IDocumentModelBuilder
    {
        private DocumentModel DocumentModel { get; set; }

        public DocumentModelBuilder()
        {
            DocumentModel = new DocumentModel();
        }

        public void Reset()
        {
            DocumentModel = new DocumentModel();
        }

        public IDocumentModelBuilder SetUpdateDate(DateTime date)
        {
            DocumentModel.UpdateDate = date;
            return this;
        }

        public IDocumentModelBuilder SetAlias(string name)
        {
            DocumentModel.Alias = Alias.Generate(name);
            return this;
        }

        public IDocumentModelBuilder SetVersion(int version = 1)
        {
            DocumentModel.Version = version;
            return this;
        }

        public IDocumentModelBuilder SetAuthor(string author)
        {
            // TO DO integrate this feature with user system
            DocumentModel.AuthorId = author;
            return this;
        }

        public IDocumentModelBuilder SetProperties(List<PropertyGroup> properties)
        {
            DocumentModel.PropertyGroups = properties;
            return this;
        }

        public IDocumentModelBuilder SetValuesFromJson(DocumentModelDto model)
        {
            DocumentModel.Name = model.Name;
            DocumentModel.Alias = Alias.Generate(DocumentModel.Name);
            DocumentModel.Version = 1;
            DocumentModel.AuthorId = model.AuthorId;
            DocumentModel.UpdateDate = DateTime.Now;
            DocumentModel.PropertyGroups = GetPropertyGroups(model.PropertyGroups);
            return this;
        }

        public DocumentModel GetDocumentModel()
        {
            return DocumentModel;
        }
        
        /// <summary>
        /// Converts a dto property group model to the actual property group model.
        /// Assumes that the dto object is validated.
        /// </summary>
        /// <param name="dtoGroups">A collection of DataTransferObjects.PropertyGroup</param>
        /// <returns></returns>
        private static List<PropertyGroup> GetPropertyGroups(IEnumerable<DataTransferObjects.PropertyGroup> dtoGroups)
        {
            List<PropertyGroup> propertyGroups = new List<PropertyGroup>();
            
            foreach (DataTransferObjects.PropertyGroup propertyGroup in dtoGroups)
            {
                List<Property> properties = propertyGroup.Properties.Select(property => 
                    new Property()
                    {
                        Alias = Alias.Generate(property.Name), 
                        Type = property.Type, 
                        Name = property.Name,
                        Description = property.Description,
                        Required = property.Required
                    }).ToList();

                propertyGroups.Add(new PropertyGroup()
                {
                    Name = propertyGroup.Name,
                    Alias = Alias.Generate(propertyGroup.Name),
                    Properties = properties
                });
            }

            return propertyGroups;
        }
    }
}