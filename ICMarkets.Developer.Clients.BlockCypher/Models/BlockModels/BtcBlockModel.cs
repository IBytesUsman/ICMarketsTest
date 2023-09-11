using Newtonsoft.Json;

namespace ICMarkets.Developer.Clients.BlockCypher.Models.BlockModels;
public class BtcBlockModel : BaseBlockModel
{
    [JsonProperty("high_fee_per_kb")]
    public long HighFeePerKb { get; set; } = 0;

    [JsonProperty("medium_fee_per_kb")]
    public long MediumFeePerKb { get; set; } = 0;

    [JsonProperty("low_fee_per_kb")]
    public long LowFeePerKb { get; set; } = 0;
}