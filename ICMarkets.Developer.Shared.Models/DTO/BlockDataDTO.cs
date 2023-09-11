using Newtonsoft.Json;

namespace ICMarkets.Developer.Shared.Models.DTO;
public class BlockDataDTO
{
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("height")]
    public long Height { get; set; } = 0;

    [JsonProperty("hash")]
    public string Hash { get; set; } = string.Empty;

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

    [JsonProperty("high_gas_price")]
    public long? HighGasPrice { get; set; } = null;

    [JsonProperty("medium_gas_price")]
    public long? MediumGasPrice { get; set; } = null;

    [JsonProperty("low_gas_price")]
    public long? LowGasPrice { get; set; } = null;

    [JsonProperty("high_priority_fee")]
    public long? HighPriorityFee { get; set; } = null;

    [JsonProperty("medium_priority_fee")]
    public long? MediumPriorityFee { get; set; } = null;

    [JsonProperty("low_priority_fee")]
    public long? LowPriorityFee { get; set; } = null;

    [JsonProperty("base_fee")]
    public long? BaseFee { get; set; } = null;

    [JsonProperty("last_fork_height")]
    public long LastForkHeight { get; set; } = 0;

    [JsonProperty("high_fee_per_kb")]
    public long? HighFeePerKb { get; set; } = null;

    [JsonProperty("medium_fee_per_kb")]
    public long? MediumFeePerKb { get; set; } = null;

    [JsonProperty("low_fee_per_kb")]
    public long? LowFeePerKb { get; set; } = null;

    [JsonProperty("last_fork_hash")]
    public string LastForkHash { get; set; } = string.Empty;
    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
