using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Freshnet.Data.Models
{
    public class DocumentModel
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
        public DateTime UpdateDate { get; set; }
        
    }
}