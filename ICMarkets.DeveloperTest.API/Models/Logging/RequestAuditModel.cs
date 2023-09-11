namespace ICMarkets.DeveloperTest.API.Models.Logging;
public class RequestAuditModel
{
    public DateTime Date { get; set; }
    public string Method { get; set; }
    public string Path { get; set; }
    public string Body { get; set; }
}