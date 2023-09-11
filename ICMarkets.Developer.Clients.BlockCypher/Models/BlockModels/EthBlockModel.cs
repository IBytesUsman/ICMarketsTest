using Newtonsoft.Json;

namespace ICMarkets.Developer.Clients.BlockCypher.Models.BlockModels;
public class EthBlockModel : BaseBlockModel
{
    [JsonProperty("high_gas_price")]
    public long HighGasPrice { get; set; } = 0;

    [JsonProperty("medium_gas_price")]
    public long MediumGasPrice { get; set; } = 0;

    [JsonProperty("low_gas_price")]
    public long LowGasPrice { get; set; } = 0;

    [JsonProperty("high_priority_fee")]
    public long HighPriorityFee { get; set; } = 0;

    [JsonProperty("medium_priority_fee")]
    public long MediumPriorityFee { get; set; } = 0;

    [JsonProperty("low_priority_fee")]
    public long LowPriorityFee { get; set; } = 0;

    [JsonProperty("base_fee")]
    public long BaseFee { get; set; } = 0;

    [JsonProperty("last_fork_height")]
    public long LastForkHeight { get; set; } = 0;

    [JsonProperty("last_fork_hash")]
    public string LastForkHash { get; set; } = string.Empty;
}