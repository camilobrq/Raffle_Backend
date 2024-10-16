using Domain.Entities.Base;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Infrastructura.Middleware;

public class ExceptionMiddleware(RequestDelegate _next, ILogger<ExceptionMiddleware> _logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            _logger.LogInformation("Handling request: {Name}", context.Request.Path);
            await _next(context);
        }
        catch (Exception ex)
        {

            _logger.LogError(ex, "An unhandled exception has occurred: {Name}", ex.Message);
            _logger.LogError(ex, "StackTrace: {Name}", ex.StackTrace);
            await GetResult(ex, context);
        }
        finally
        {
            _logger.LogInformation("Finished handling request.");
        }
    }

    private static async Task GetResult(Exception exception, HttpContext context)
    {
        switch (exception)
        {
            case ConflictException conflictException:
                await OnCustomConflictException(context, conflictException);
                break;

            case NoContentException noContentException:
                await OnCustomNotFoundException(context, noContentException);
                break;

            case IncorrectCredentialsException incorrectCredentialsException:
                await OnCustomConflictException(context, incorrectCredentialsException);
                break;

            case DuplicateCredentialsException duplicateCredentialsException:
                await OnCustomNotFoundException(context, duplicateCredentialsException);
                break;

            case FailCredentialsException failCredentialsException:
                await OnCustomNotRefreshException(context, failCredentialsException);
                break;

            default:
                await SendResult(context, exception, HttpStatusCode.InternalServerError);
                break;
        }
    }

    private static async Task OnCustomConflictException(HttpContext context, Exception exception)
    {
        await SendResult(context, exception, HttpStatusCode.Conflict);
    }

    private static async Task OnCustomNotFoundException(HttpContext context, Exception exception)
    {
        await SendResult(context, exception, HttpStatusCode.NoContent);
    }

    private static async Task OnCustomNotRefreshException(HttpContext context, Exception exception)
    {
        await SendResult(context, exception, HttpStatusCode.Forbidden);
    }

    private static async Task SendResult(HttpContext context, Exception exception, HttpStatusCode code)
    {
        var message = GetMessage(exception);
        var response = new ServiceResponse(message,false);
        var jsonReponse = JsonSerializer.Serialize(response);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        await context.Response.WriteAsync(jsonReponse);
    }

    private static string GetMessage(Exception exception)
    {
        try
        {
            return exception.Message;
        }
        catch (Exception)
        {
            return "Not-Message-Defined";
        }
    }
}
