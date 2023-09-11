using ICMarkets.DeveloperTest.Datacontext.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICMarkets.DeveloperTest.Datacontext;
public class ICMarketsDbContext : DbContext
{
    public ICMarketsDbContext(DbContextOptions<ICMarketsDbContext> options)
       : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BlockchainDataEntity>().Property(e => e.HighGasPrice).IsRequired(false);
        modelBuilder.Entity<BlockchainDataEntity>().Property(e => e.MediumGasPrice).IsRequired(false);
        modelBuilder.Entity<BlockchainDataEntity>().Property(e => e.LowGasPrice).IsRequired(false);

        modelBuilder.Entity<BlockchainDataEntity>().Property(e => e.HighPriorityFee).IsRequired(false);
        modelBuilder.Entity<BlockchainDataEntity>().Property(e => e.MediumPriorityFee).IsRequired(false);
        modelBuilder.Entity<BlockchainDataEntity>().Property(e => e.LowPriorityFee).IsRequired(false);

        modelBuilder.Entity<BlockchainDataEntity>().Property(e => e.BaseFee).IsRequired(false);

        modelBuilder.Entity<BlockchainDataEntity>().Property(e => e.HighFeePerKb).IsRequired(false);
        modelBuilder.Entity<BlockchainDataEntity>().Property(e => e.MediumFeePerKb).IsRequired(false);
        modelBuilder.Entity<BlockchainDataEntity>().Property(e => e.LowFeePerKb).IsRequired(false);
    }

    public DbSet<BlockchainDataEntity> BlockchainData { get; set; }
    public DbSet<ExceptionEntity> ExceptionsAudit { get; set; }
    public DbSet<RequestEntity> RequestsAudit { get; set; }
}
