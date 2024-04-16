namespace Smart.Admin.Template.RestApi.Infrastructure.CrossCutting.Errors;

using FluentValidation.Results;
using ToolBox.Framework.Error;

/// <summary>
/// Represents an interface for converting validation failures to application error collection.
/// </summary>
public interface IOutputErrorConverter
{
    /// <summary>
    /// Converts a collection of validation failures to an ApplicationErrorCollection object. </summary> <param name="validationFailures">The collection of validation failures.</param> <returns>
    /// An instance of the ApplicationErrorCollection class that contains the converted validation failures. </returns>
    /// /
    ApplicationErrorCollection ToResponse(IEnumerable<ValidationFailure> validationFailures);
}