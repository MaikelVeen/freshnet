using System.Collections.Generic;

namespace Freshnet.Data.DataTransferObjects
{
    public class DocumentModelDto
    {
        public string Name { get; set; }
        public string AuthorId { get; set; }
        public List<PropertyGroup> PropertyGroups { get; set; }
    }

    public class PropertyGroup
    {
        public string Name { get; set; }
        public List<Property> Properties { get; set; }
    }

    public class Property
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
    }
}