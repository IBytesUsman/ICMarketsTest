using ICMarkets.Developer.Shared.Models.Enums;

namespace ICMarkets.DeveloperTest.Datacontext.Entities;
public class BlockchainDataEntity
{
    public long Id { get; set; }
    public BlockTypeEnum Type { get; set; }
    public string Name { get; set; } = string.Empty;

    public long Height { get; set; } = 0;

    public string Hash { get; set; } = string.Empty;

    public DateTime Time { get; set; } = DateTime.UtcNow;

    public string LatestUrl { get; set; } = string.Empty;

    public string PreviousHash { get; set; } = string.Empty;

    public string PreviousUrl { get; set; } = string.Empty;

    public int PeerCount { get; set; } = 0;

    public int UnconfirmedCount { get; set; } = 0;

    public long? HighGasPrice { get; set; } = null;

    public long? MediumGasPrice { get; set; } = null;

    public long? LowGasPrice { get; set; } = null;

    public long? HighPriorityFee { get; set; } = null;

    public long? MediumPriorityFee { get; set; } = null;

    public long? LowPriorityFee { get; set; } = null;

    public long? BaseFee { get; set; } = null;

    public long LastForkHeight { get; set; } = 0;

    public string LastForkHash { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public long? HighFeePerKb { get; set; } = null;

    public long? MediumFeePerKb { get; set; } = null;

    public long? LowFeePerKb { get; set; } = null;
}