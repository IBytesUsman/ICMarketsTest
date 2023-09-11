using ICMarkets.DeveloperTest.Datacontext.Entities;

namespace ICMarkets.DeveloperTest.Datacontext.Repositories.Interfaces;
public interface IExceptionRepository
{
    Task<ExceptionEntity> CreateAsync(ExceptionEntity entity, CancellationToken cancellationToken);
}
