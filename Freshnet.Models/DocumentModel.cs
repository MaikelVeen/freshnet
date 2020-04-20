using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Freshnet.Models
{
    public class DocumentModel : IDocumentModel
    {
        public DocumentModel()
        {
            Id = ObjectId.GenerateNewId();
        }

        /// <summary>
        /// Numerical representation of the document type
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        /// <summary>
        /// The name of the document model
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Alias of the document type that will be used in API routing
        /// Generated based on the name
        /// </summary>
        public string Alias { get; set; }
        
        /// <summary>
        /// Current version of the 
        /// </summary>
        public int Version { get; set; }
        
        public string AuthorId { get; set; }

        public List<PropertyGroup> PropertyGroups { get; set; }
        
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        
        public bool Update(IDocumentModel model)
        {
            throw new NotImplementedException();
        }

        public string GenerateAlias(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Name of document model cannot be null");
            }
            
            StringBuilder stringBuilder = new StringBuilder(name.Trim());
            stringBuilder[0] = char.ToLower(stringBuilder[0]);
            return stringBuilder.ToString();
        }
    }
}