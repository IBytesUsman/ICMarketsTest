using AutoMapper;
using ICMarkets.DeveloperTest.API.Infrastructure.Services;
using ICMarkets.DeveloperTest.API.Infrastructure.Services.Interfaces;
using ICMarkets.DeveloperTest.API.Models.Logging;
using ICMarkets.DeveloperTest.Datacontext.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;

namespace ICMarkets.DeveloperTest.API.Infrastructure.Middlewares;
public class ErrorHandlingMiddleware
{
    public RequestDelegate _requestDelegate;
    private readonly IAuditLogService _auditLogService;
    public ErrorHandlingMiddleware(RequestDelegate requestDelegate,
        IAuditLogService auditLogService,
        IExceptionRepository exceptionRepository,
        IMapper mapper)
    {
        _requestDelegate = requestDelegate;
        _auditLogService = auditLogService;
        _auditLogService = new ExceptionAuditLogService(exceptionRepository, mapper);
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _requestDelegate(context);
        }
        catch (Exception ex)
        {
            if (context.Request.Path != "/hangfire")
            {
                await HandleException(context, ex, _auditLogService);
            }
        }
    }
    private static Task HandleException(HttpContext context, Exception ex, IAuditLogService auditLogService)
    {
        var requestId = context.TraceIdentifier;
        var method = context.Request.Method;
        var path = context.Request.Path;

        var errorMessage = JsonConvert.SerializeObject(
            new
            {
                RequestId = requestId,
                Message = "Internal Server Error",
                Code = HttpStatusCode.InternalServerError
            });

        auditLogService.CreateAuditLogAsync(new ExceptionAuditModel()
        {
            RequestId = requestId,
            Path = path,
            Action = method,
            Date = DateTime.UtcNow,
            Metadata = string.Empty,
            ExceptionMessage = ex.Message,
            StackTrace = ex.StackTrace ?? ex.Message
        }, CancellationToken.None);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 500;
        return context.Response.WriteAsync(errorMessage);
    }
}
