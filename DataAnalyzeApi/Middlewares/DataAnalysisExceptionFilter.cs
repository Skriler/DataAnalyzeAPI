using DataAnalyzeApi.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DataAnalyzeApi.Middlewares;

/// <summary>
/// Exception filter for handling business logic errors.
/// Logs the error and creates ProblemDetails with additional information for the response to the client.
/// </summary>
public class DataAnalysisExceptionFilter(
    ILogger<DataAnalysisExceptionFilter> logger,
    IHostEnvironment environment
    ) : IExceptionFilter
{
    private readonly ILogger<DataAnalysisExceptionFilter> logger = logger;
    private readonly IHostEnvironment environment = environment;

    /// <summary>
    /// Handles exceptions of type DataAnalyzeException.
    /// Logs the error information and prepares a response with problem details.
    /// </summary>
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is not DataAnalysisException ex)
            return;

        logger.LogWarning(
            ex,
            "Business exception occurred: {ErrorTitle} - {Message}",
            ex.ErrorTitle,
            ex.Message);

        var problemDetails = new ProblemDetails
        {
            Title = ex.ErrorTitle,
            Status = ex.StatusCode,
            Detail = ex.Message,
            Instance = context.HttpContext.Request.Path,
        };

        problemDetails.Extensions["timestamp"] = DateTime.UtcNow;

        if (environment.IsDevelopment())
        {
            problemDetails.Extensions["stackTrace"] = ex.StackTrace;
        }

        context.Result = new ObjectResult(problemDetails)
        {
            StatusCode = ex.StatusCode
        };

        context.ExceptionHandled = true;
    }
}

public static partial class ErrorHandlingExtensions
{
    /// <summary>
    /// Extension method for registering the DataAnalyzeExceptionFilter.
    /// </summary>
    public static IMvcBuilder AddDataAnalyzeExceptionFilters(this IMvcBuilder builder)
    {
        builder.AddMvcOptions(options => options.Filters.Add<DataAnalysisExceptionFilter>());

        return builder;
    }
}
