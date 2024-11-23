using Infrastruture.Shared.Wrappers;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace WebAPI.Middleware
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;
        public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                string ex1 = ex.Message.ToString();
            }

            var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

            if (exceptionHandlerFeature != null)
            {
                var exception = exceptionHandlerFeature.Error;

                // Log the exception
                //_logger.LogError(exception, "An unhandled exception occurred");

                // Build the error response
                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "An unexpected error occurred",
                    Detail = exception.Message,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
                };
                var responseModel = new Response<string>() { Succeeded = false, Message = exception.Message };
                //if (exceptionHandlerFeature is FluentValidation.ValidationException fluentException)
                //{
                //    List<string> validationErrors = new List<string>();
                //    foreach (var error in fluentException.Errors)
                //    {
                //        validationErrors.Add(error.ErrorMessage);
                //    }
                //    problemDetails.Extensions.Add("errors", validationErrors);
                //}

                // Customize response based on specific exceptions (optional)
                if (exception is UnauthorizedAccessException)
                {
                    problemDetails.Status = StatusCodes.Status401Unauthorized;
                    problemDetails.Title = "Unauthorized access";
                }
                else if (exception is KeyNotFoundException)
                {
                    problemDetails.Status = StatusCodes.Status404NotFound;
                    problemDetails.Title = "Resource not found";
                }

                // Set response
                context.Response.StatusCode = problemDetails.Status ?? (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                //await context.Response.WriteAsJsonAsync(problemDetails);
                var json = JsonSerializer.Serialize(responseModel);
                await context.Response.WriteAsync(json);
            }



        }

    }

}
