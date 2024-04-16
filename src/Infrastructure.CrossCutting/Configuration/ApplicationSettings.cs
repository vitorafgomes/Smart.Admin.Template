namespace Smart.Admin.Template.RestApi.Infrastructure.CrossCutting.Configuration;

/// <summary>
/// Represents the settings for the application.
/// </summary>
public sealed class ApplicationSettings
{
    /// <summary>
    /// Gets or sets the logging settings.
    /// </summary>
    public LoggingSettings Logging { get; set; }

    /// <summary>
    /// Gets or sets the configurations for Swagger.
    /// </summary>
    public SwaggerSettings Swagger { get; set; }

    public MongoSettings Mongo { get; set; }

    public OpenTelemetrySettings OpenTelemetry { get; set; }
}