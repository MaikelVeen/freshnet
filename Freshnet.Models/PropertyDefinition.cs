namespace Freshnet.Models
{
    public abstract class PropertyDefinition : IPropertyDefinition<object>
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string TypeAlias { get; set; }
    }
}