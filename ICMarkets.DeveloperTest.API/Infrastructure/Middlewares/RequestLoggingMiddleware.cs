using AutoMapper;
using ICMarkets.DeveloperTest.API.Infrastructure.Services;
using ICMarkets.DeveloperTest.API.Infrastructure.Services.Interfaces;
using ICMarkets.DeveloperTest.API.Models.Logging;
using ICMarkets.DeveloperTest.Datacontext.Repositories.Interfaces;
using Microsoft.Extensions.Options;

namespace ICMarkets.DeveloperTest.API.Infrastructure.Middlewares;
public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IAuditLogService _auditLogService;
    public RequestLoggingMiddleware(
        RequestDelegate next,
        IAuditLogService auditLogService,
        IOptions<ApplicationConfiguration> applicationConfiguation,
        IRequestRepository requestRepository,
        IMapper mapper)
    {
        _next = next;
        _auditLogService = auditLogService;
        _auditLogService = new RequestAuditLogService(requestRepository, mapper);
    }

    public async Task Invoke(HttpContext context)
    {
        context.Request.EnableBuffering();

        var request = context.Request;
        var requestBodyStream = new MemoryStream();
        await request.Body.CopyToAsync(requestBodyStream);
        requestBodyStream.Seek(0, SeekOrigin.Begin);
        var requestBodyText = new StreamReader(requestBodyStream).ReadToEnd();

        await _auditLogService.CreateAuditLogAsync(new RequestAuditModel()
        {
            Date = DateTime.UtcNow,
            Method = request.Method,
            Path = request.Path,
            Body = requestBodyText
        }, CancellationToken.None);

        requestBodyStream.Seek(0, SeekOrigin.Begin);
        context.Request.Body = requestBodyStream;

        await _next(context);
    }
}