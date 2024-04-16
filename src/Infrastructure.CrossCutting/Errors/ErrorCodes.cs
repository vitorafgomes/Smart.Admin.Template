namespace Smart.Admin.Template.RestApi.Infrastructure.CrossCutting.Errors;

/// <summary>
/// Class that contains the error codes used in the application.
/// </summary>
public sealed class ErrorCodes
{
    public static class GenericErrorCodes
    {
        public const string None = "0";

        /// <summary>
        /// A required HTTP header was not specified.
        /// </summary>
        public const string MissingRequiredHeader = "1";

        /// <summary>
        /// One of the HTTP headers specified in the request is not supported.
        /// </summary>
        public const string UnsupportedHeader = "2";

        /// <summary>
        /// The value provided for one of the HTTP headers was not in the correct format.
        /// </summary>
        public const string InvalidHeaderValue = "3";

        /// <summary>
        /// A required query parameter was not specified for this request.
        /// </summary>
        public const string MissingRequiredParameter = "4";

        /// <summary>
        /// One of the query parameters specified in the request URI is not supported.
        /// </summary>
        public const string UnsupportedParameter = "5";

        /// <summary>
        /// An invalid value was specified for one of the query parameters in the request URI.
        /// </summary>
        public const string InvalidParameterValue = "6";

        /// <summary>
        /// A query parameter specified in the request URI is outside the permissible range.
        /// </summary>
        public const string OutOfRangeParameterValue = "7";

        /// <summary>
        /// The requested URI does not represent any resource on the server.
        /// </summary>
        public const string InvalidUri = "8";

        /// <summary>
        /// The HTTP verb specified was not recognized by the server.
        /// </summary>
        public const string InvalidHttpVerb = "9";

        /// <summary>
        /// The authentication information was not provided in the correct format. Verify the value of Authorization header.
        /// </summary>
        public const string InvalidAuthenticationInfo = "10";

        /// <summary>
        /// Condition headers are not supported.
        /// </summary>
        public const string ConditionHeadersNotSupported = "11";

        /// <summary>
        /// Multiple condition headers are not supported.
        /// </summary>
        public const string MultipleConditionHeadersNotSupported = "12";

        /// <summary>
        /// The user has not yet been authenticated or the login has failed.
        /// </summary>
        public const string UserNotAuthenticated = "13";

        /// <summary>
        /// The specified account is disabled.
        /// </summary>
        public const string AccountIsDisabled = "14";

        /// <summary>
        /// The account being accessed does not have sufficient permissions to execute this operation.
        /// </summary>
        public const string InsufficientAccountPermissions = "15";

        /// <summary>
        /// The specified resource does not exist.
        /// </summary>
        public const string ResourceNotFound = "16";

        /// <summary>
        /// The resource returned no results.
        /// </summary>
        public const string NoResultsFound = "17";

        /// <summary>
        /// The resource doesn't support the specified HTTP verb.
        /// </summary>
        public const string UnsupportedHttpVerb = "18";

        /// <summary>
        /// The server encountered an internal error. Please retry the request.
        /// </summary>
        public const string InternalError = "19";

        /// <summary>
        /// The operation could not be completed within the permitted time.
        /// </summary>
        public const string OperationTimedOut = "20";

        /// <summary>
        /// The server is currently unable to receive requests. Please retry your request.
        /// </summary>
        public const string ServerBusy = "21";

        /// <summary>
        /// The resource already exist. Try to update.
        /// </summary>
        public const string ResourceAlreadyExists = "22";

        /// <summary>
        /// Tenant identifier is invalid
        /// </summary>
        public const string InvalidTenantIdentifier = "101";

        /// <summary>
        /// Invalid Resource Identifier
        /// </summary>
        public const string InvalidResourceIdentifier = "102";

        /// <summary>
        /// Invalid State to execute operation.
        /// </summary>
        public const string InvalidStateToExecuteOperation = "103";

        /// <summary>
        /// Invalid Patch Document. Refer to http://tools.ietf.org/html/rfc6902
        /// </summary>
        public const string InvalidPatchDocument = "104";
    }
}