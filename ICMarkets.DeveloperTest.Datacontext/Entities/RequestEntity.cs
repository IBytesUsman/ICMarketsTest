namespace ICMarkets.DeveloperTest.Datacontext.Entities;
public class RequestEntity
{
    public long Id { get; set; } = 0;
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public string Method { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
}
