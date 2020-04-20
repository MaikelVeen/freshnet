namespace Freshnet.Data
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ModelDocumentCollection { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string ModelDocumentCollection { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}