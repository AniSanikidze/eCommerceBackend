using eCommerce.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Auth.Api.Middlewares
{
    public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

                var exceptionDetails = GetExceptionDetails(exception);
                var problemDetails = new ProblemDetails()
                {
                    Status = exceptionDetails.Status,
                    Type = exceptionDetails.Type,
                    Title = exceptionDetails.Title,
                    Detail = exceptionDetails.Detail
                };

                if (exceptionDetails.Errors is not null)
                    problemDetails.Extensions["errors"] = exceptionDetails.Errors;

                context.Response.StatusCode = exceptionDetails.Status;
                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }

        private ExceptionDetails GetExceptionDetails(Exception exception)
        {
            return exception switch
            {
                ValidationException validationException => new ExceptionDetails(
                    StatusCodes.Status400BadRequest,
                    "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                    "Validation error",
                    "ვალიდაციის შეცდომა",
                    validationException.Errors.Select(error => new KeyValuePair<string, string[]>(error.Key, error.Value)).ToList()
                ),
                NotFoundException notFoundException => new ExceptionDetails(
                    StatusCodes.Status400BadRequest,
                    "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
                    "Not found error",
                    notFoundException.Message,
                    null
                ),
                _ => new ExceptionDetails(
                    StatusCodes.Status500InternalServerError,
                    "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                    "Server error",
                    "სისტემური შეცდომა",
                    null
                )
            };
        }

        internal record ExceptionDetails(
            int Status,
            string Type,
            string Title,
            string Detail,
            IEnumerable<KeyValuePair<string, string[]>>? Errors);
    }
}
