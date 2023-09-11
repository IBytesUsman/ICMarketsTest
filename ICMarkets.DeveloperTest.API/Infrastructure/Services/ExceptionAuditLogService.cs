using AutoMapper;
using ICMarkets.DeveloperTest.API.Infrastructure.Services.Interfaces;
using ICMarkets.DeveloperTest.API.Models.Logging;
using ICMarkets.DeveloperTest.Datacontext.Entities;
using ICMarkets.DeveloperTest.Datacontext.Repositories.Interfaces;

namespace ICMarkets.DeveloperTest.API.Infrastructure.Services;
public class ExceptionAuditLogService : IAuditLogService
{
    private readonly IExceptionRepository _exceptionRepository;
    private readonly IMapper _mapper;
    public ExceptionAuditLogService(
        IExceptionRepository exceptionRepository,
        IMapper mapper)
    {
        _exceptionRepository= exceptionRepository;
        _mapper = mapper;
    }

    public async Task<bool> CreateAuditLogAsync(object auditLogModel, CancellationToken cancellationToken)
    {
        var model = (ExceptionAuditModel)auditLogModel;
        var entity = _mapper.Map<ExceptionEntity>(model);
        await _exceptionRepository.CreateAsync(entity, cancellationToken);
        return true;
    }
}