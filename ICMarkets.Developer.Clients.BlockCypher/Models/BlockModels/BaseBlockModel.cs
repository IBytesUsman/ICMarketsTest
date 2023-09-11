using Newtonsoft.Json;

namespace ICMarkets.Developer.Clients.BlockCypher.Models.BlockModels;
public class BaseBlockModel
{
    [JsonProperty("name")]
    public string Name { get; set; } =string.Empty;

    [JsonProperty("height")]
    public long Height { get; set; } = 0;

    [JsonProperty("hash")]
    public string Hash { get; set; }=string.Empty;

    [JsonProperty("time")]
    public DateTime Time { get; set; } = DateTime.UtcNow;

    [JsonProperty("latest_url")]
    public string LatestUrl { get; set; } = string.Empty;

    [JsonProperty("previous_hash")]
    public string PreviousHash { get; set; } = string.Empty;

    [JsonProperty("previous_url")]
    public string PreviousUrl { get; set; } = string.Empty;

    [JsonProperty("peer_count")]
    public int PeerCount { get; set; } = 0;

    [JsonProperty("unconfirmed_count")]
    public int UnconfirmedCount { get; set; } = 0;

    
}