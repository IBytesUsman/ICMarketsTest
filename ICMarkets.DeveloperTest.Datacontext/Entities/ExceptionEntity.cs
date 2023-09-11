namespace ICMarkets.DeveloperTest.Datacontext.Entities;
public class ExceptionEntity
{
    public long Id { get; set; } = 0;
    public string RequestId { get; set; } = string.Empty;

    public DateTime Date { get; set; } = DateTime.UtcNow;

    public string Action { get; set; } = string.Empty;

    public string Path { get; set; } = string.Empty;

    public string Metadata { get; set; } = string.Empty;

    public string ExceptionMessage { get; set; } = string.Empty;

    public string StackTrace { get; set; } = string.Empty;

}
