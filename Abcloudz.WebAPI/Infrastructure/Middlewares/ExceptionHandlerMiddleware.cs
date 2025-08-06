using Microsoft.AspNetCore.Mvc;

namespace Abcloudz.WebAPI.Infrastructure.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                ProblemDetails? problemDetails = null;

                if (ex is ArgumentException argEx)
                {
                    problemDetails = new ProblemDetails
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Title = argEx.Message
                    };

                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                } else
                {
                    problemDetails = new ProblemDetails
                    {
                        Status = StatusCodes.Status500InternalServerError,
                        Title = "Server Error"
                    };

                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                }

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }
    }
}
