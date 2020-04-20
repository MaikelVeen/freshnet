using System.Collections.Generic;

namespace Freshnet.Models
{
    public class PropertyGroup
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public List<Property> Properties { get; set; }
    }
}