namespace Smart.Admin.Template.RestApi.Api.Modules;

using System.Text.Json;
using Infrastructure.CrossCutting.Errors;
using Infrastructure.CrossCutting.SourceGenerationContext;
using Microsoft.AspNetCore.Diagnostics;
using ToolBox.Framework.Error;
using ToolBox.Framework.Logging;

/// <summary>
/// Contains extension methods for handling exceptions in the ASP.NET Core pipeline.
/// </summary>
internal static class ExceptionHandlingExtensions
{
    /// <summary>
    /// Logs unhandled exceptions and returns a JSON response with error details.
    /// </summary>
    /// <param name="applicationBuilder">The application builder.</param>
    internal static void LogUnhandledExceptions(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.Use(async (context, next) =>
        {
            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            Log.Error(exceptionHandlerPathFeature.Error.Message, exceptionHandlerPathFeature.Error);

            var applicationError = ConstructApplicationError(exceptionHandlerPathFeature.Error);

            var errorResponse = JsonSerializer.Serialize(applicationError, ApplicationErrorContext.Default.ApplicationError);
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(errorResponse);

            await next();
        });
    }

    /// <summary>
    /// Constructs an ApplicationError object from an given exception.
    /// </summary>
    private static ApplicationError ConstructApplicationError(Exception error)
    {
        return new ApplicationError()
        {
            Exception = error,
            Code = ErrorCodes.GenericErrorCodes.InternalError,
            Message = error.Message,
        };
    }
}