namespace Freshnet.Data.Models
{
    public class Property
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Type { get; set; }

        public string Description { get; set; }

        public bool Required { get; set; }
    }
}