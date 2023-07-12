using CleanArchitectureDemo.Shared;
using FluentValidation;
using Newtonsoft.Json;
using System.Net;

namespace CleanArchitectureDemo.WebAPI.Middleware;

internal sealed class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate next;

    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        this.next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var result = string.Empty;

        context.Response.ContentType = "application/json";

        _logger.LogDebug("Test");

        if (exception.GetType() == typeof(ValidationException))
        {
            var errors = ((ValidationException)exception)
                            .Errors
                            .Select(s => new ValidationResult { Key = s.PropertyName, Value = s.ErrorMessage })
                            .ToList();

            var validationResult = Result<List<ValidationResult>>.Failure(errors);
            validationResult.Messages.Add("Validation Exception");

            result = JsonConvert.SerializeObject(validationResult);

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            _logger.LogInformation(result);
        }
        else
        {
            var errorResult = Result<List<ValidationResult>>.Failure(exception);
            errorResult.Messages.Add(exception.Message);

            result = JsonConvert.SerializeObject(errorResult);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            _logger.LogError(result);
        }

        return context.Response.WriteAsync(result);
    }
}
