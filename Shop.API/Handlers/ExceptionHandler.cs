using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Shop.Contracts.Exceptions;

namespace Shop.API.Handlers
{
    public class ExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var problemDetails = CreateProblemDetails(exception);
            httpContext.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(problemDetails,cancellationToken);
            return true;
        }       

        private static ProblemDetails CreateProblemDetails(Exception exception)
        {
            ProblemDetails problemDetails = exception switch
            {
                NotFoundException => CreateProblemDetails(StatusCodes.Status404NotFound, "Not Found", exception.Message),
                CustomValidationException => CreateProblemDetails(StatusCodes.Status400BadRequest, "Validation error", "One or more validations"),
                _ => CreateProblemDetails(StatusCodes.Status500InternalServerError, "Internal Server Error", " an unexpected error occurred!")
            };
            if (exception is CustomValidationException customValidationException)
            {
                problemDetails.Extensions["errors"] = customValidationException.Errors;
            }
            return problemDetails;
        }
        private static ProblemDetails CreateProblemDetails(int status, string title, string details)
        {
            return new ProblemDetails
            {
                Status = status,
                Title = title,
                Detail = details
            };
        } 
    }
}
