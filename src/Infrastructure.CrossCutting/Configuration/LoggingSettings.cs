namespace Smart.Admin.Template.RestApi.Infrastructure.CrossCutting.Configuration;

using ToolBox.Framework.Logging;

/// <summary>
/// Represents the settings for logging.
/// </summary>
public sealed class LoggingSettings
{
    /// <summary>
    /// Gets or sets the directory path.
    /// </summary>
    /// <remarks>
    /// This property represents the directory path. It can be used to retrieve or update the path of a directory.
    /// </remarks>
    public string Directory { get; set; }

    /// <summary>
    /// Represents the logging level of a system.
    /// </summary>microsoft.visualstudio.azure.containers.tools.targets
    public LogLevel LogLevel { get; set; }

    /// <summary>
    /// Gets or sets the name of the file.
    /// </summary>
    /// <value>
    /// The name of the file.
    /// </value>
    public string NameFile { get; set; }
}