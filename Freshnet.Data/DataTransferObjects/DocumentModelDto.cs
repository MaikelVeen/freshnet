using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Freshnet.Data.DataTransferObjects
{
    public class DocumentModelDto
    {
        [Required]
        public string Name { get; set; }
        public string AuthorId { get; set; }
        [Required]
        public List<PropertyGroup> PropertyGroups { get; set; }
    }

    public class PropertyGroup
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public List<Property> Properties { get; set; }
    }

    public class Property
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        public string Description { get; set; }
        [Required]
        public bool Required { get; set; }
    }
}