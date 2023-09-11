namespace ICMarkets.DeveloperTest.Datacontext.DOs;
public class BaseQueryDo
{
    public int Limit { get; set; }
    public bool Nested { get; set; }
    public bool Tracking { get; set; }
    public BaseQueryDo()
    {
        Limit = -1;
        Nested = false;
        Tracking = false;
    }
}
