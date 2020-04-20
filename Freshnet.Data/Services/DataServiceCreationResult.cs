namespace Freshnet.Data.Services
{
    public class DataServiceCreationResult
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
    
    public static class DataServiceCreationResultMessages
    {
        public static string Succeeded { get; } = "Data entry succeeded";
        public static string Failed { get; } = "Data entry failed";
        public static string Duplicate { get; } = "Cannot create data entry with duplicate";
    }
}