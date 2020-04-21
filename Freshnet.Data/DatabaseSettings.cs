namespace Freshnet.Data
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string DocumentModelCollection { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string DocumentModelCollection { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}