using System.Net;
using System.Text.Json;

namespace Abcloudz.WebAPI.Middleware
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;

		public ExceptionMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}

		private static Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			var response = new
			{
				message = exception.Message,
				error = "Internal Server Error",
				statusCode = (int)HttpStatusCode.InternalServerError
			};

			if (exception is ArgumentNullException)
			{
				response = new
				{
					message = exception.Message,
					error = "Null argument ex",
					statusCode = (int)HttpStatusCode.InternalServerError
				};
			}

			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

			var json = JsonSerializer.Serialize(response);
			return context.Response.WriteAsync(json);
		}
	}
}
