namespace Smart.Admin.Template.RestApi.Infrastructure.CrossCutting.Errors;

using FluentValidation.Results;
using ToolBox.Framework.Error;

/// <summary>
/// Converts validation failures to application error collection.
/// </summary>
public sealed class OutputErrorConverter : IOutputErrorConverter
{
    /// <summary>
    /// Converts a collection of ValidationFailures to an ApplicationErrorCollection.
    /// </summary>
    /// <param name="validationFailures">The collection of validation failures to be converted.</param>
    /// <returns>An ApplicationErrorCollection object containing the converted validation failures.</returns>
    public ApplicationErrorCollection ToResponse(IEnumerable<ValidationFailure> validationFailures)
    {
        var applicationErrors = validationFailures.Select(GetApplicationError).ToArray();

        return new ApplicationErrorCollection(applicationErrors);
    }

    /// <summary>
    /// Gets the <see cref="ApplicationError"/> object based on the provided <paramref name="validationFailure"/>.
    /// </summary>
    /// <param name="validationFailure">The validation failure instance.</param>
    /// <returns>An instance of <see cref="ApplicationError"/>.</returns>
    private static ApplicationError GetApplicationError(ValidationFailure validationFailure)
    {
        return new ApplicationError(validationFailure.ErrorCode,
            validationFailure.ErrorMessage);
    }
}