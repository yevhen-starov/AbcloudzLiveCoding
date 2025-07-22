using Abcloudz.WebAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Abcloudz.WebAPI.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionFilter(ILogger<ExceptionFilter> logger, IHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Unhandled exception occurred.");

            ErrorModel error;

            if (_env.IsDevelopment())
            {
                error = new ErrorModel(
                    500,
                    context.Exception.Message,
                    context.Exception.StackTrace
                );
            }
            else
            {
                error = new ErrorModel(
                    500,
                    "An unexpected error occurred. Please contact support.",
                    null
                );
            }

            context.Result = new JsonResult(error)
            {
                StatusCode = 500
            };
        }
    }
}
