using System.Net;
using Newtonsoft.Json;

namespace Abcloudz.WebAPI;

public class AbcloudzExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public AbcloudzExceptionHandlerMiddleware(RequestDelegate _next)
    {
        this._next = _next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var (status, message) = GetResponse(exception);
            response.StatusCode = (int) status;
            await response.WriteAsync(message);
        }
    }

    private static (HttpStatusCode code, string message) GetResponse(Exception exception)
    {
        HttpStatusCode code;
        switch (exception)
        {
            case KeyNotFoundException
                or FileNotFoundException:
                code = HttpStatusCode.NotFound;
                break;
            case UnauthorizedAccessException:
                code = HttpStatusCode.Unauthorized;
                break;
            case ArgumentException
                or InvalidOperationException:
                code = HttpStatusCode.BadRequest;
                break;
            default:
                code = HttpStatusCode.InternalServerError;
                break;
        }
        return (code, JsonConvert.SerializeObject(exception.Message));
    }
}