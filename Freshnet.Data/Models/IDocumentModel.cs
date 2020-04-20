namespace Freshnet.Data.Models
{
    public interface IDocumentModel : IDataElement
    {
        bool Update(IDocumentModel model);
        string GenerateAlias(string name);
    }
}