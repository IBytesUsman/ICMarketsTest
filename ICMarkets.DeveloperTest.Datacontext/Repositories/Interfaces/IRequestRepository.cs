using ICMarkets.DeveloperTest.Datacontext.Entities;

namespace ICMarkets.DeveloperTest.Datacontext.Repositories.Interfaces;
public interface IRequestRepository
{
    Task<RequestEntity> CreateAsync(RequestEntity entity, CancellationToken cancellationToken);
}
