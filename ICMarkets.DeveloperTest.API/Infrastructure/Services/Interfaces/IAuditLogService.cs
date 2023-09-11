namespace ICMarkets.DeveloperTest.API.Infrastructure.Services.Interfaces;
public interface IAuditLogService
{
    Task<bool> CreateAuditLogAsync(object auditLogModel, CancellationToken cancellationToken);
}