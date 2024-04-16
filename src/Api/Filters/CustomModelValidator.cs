namespace Smart.Admin.Template.RestApi.Api.Filters;

using Infrastructure.CrossCutting.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ToolBox.Framework.Error;

/// <summary>
/// Custom validator for models in an API controller. Validates the model based on the model state and returns a list of application errors if the model is invalid.
/// </summary>
public sealed class CustomModelValidator : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var applicationErrors = GenerateApplicationErrors(context.ModelState);
            var applicationErrorCollection = new ApplicationErrorCollection(applicationErrors.ToArray());
            context.Result = new BadRequestObjectResult(applicationErrorCollection);
        }
    }

    private List<ApplicationError> GenerateApplicationErrors(ModelStateDictionary modelState)
    {
        var invalidModelStateEntries = modelState.Values.Where(x => x.ValidationState == ModelValidationState.Invalid);
        var applicationErrors = new List<ApplicationError>();
        foreach (var invalidEntry in invalidModelStateEntries)
        {
            applicationErrors.AddRange(invalidEntry.Errors.Select(error => new ApplicationError(ErrorCodes.GenericErrorCodes.InvalidParameterValue, error.ErrorMessage)));
        }

        return applicationErrors;
    }
}