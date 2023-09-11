using AutoMapper;
using ICMarkets.DeveloperTest.API.Infrastructure.Services.Interfaces;
using ICMarkets.DeveloperTest.API.Models.Logging;
using ICMarkets.DeveloperTest.Datacontext.Entities;
using ICMarkets.DeveloperTest.Datacontext.Repositories.Interfaces;

namespace ICMarkets.DeveloperTest.API.Infrastructure.Services;
public class RequestAuditLogService : IAuditLogService
{
    private readonly IRequestRepository _requestRepository;
    private readonly IMapper _mapper;
    public RequestAuditLogService(
        IRequestRepository requestRepository,
        IMapper mapper)
    {
        _requestRepository = requestRepository;
        _mapper = mapper;
    }

    public async Task<bool> CreateAuditLogAsync(object auditLogModel, CancellationToken cancellationToken)
    {
        var model = (RequestAuditModel)auditLogModel;
        var entity = _mapper.Map<RequestEntity>(model);
        await _requestRepository.CreateAsync(entity, cancellationToken);
        return true;
    }
}