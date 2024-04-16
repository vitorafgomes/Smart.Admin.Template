namespace Smart.Admin.Template.RestApi.Infrastructure.CrossCutting.Configuration;

/// <summary>
/// Represents the settings for Swagger.
/// </summary>
public sealed class SwaggerSettings
{
    /// <summary>
    /// Gets or sets the title property.
    /// </summary>
    /// <value>
    /// The title.
    /// </value>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the description of a property.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Property representing a contact.
    /// </summary>
    /// <value>
    /// The contact object.
    /// </value>
    public ContactSettings Contact { get; set; }

    /// <summary>
    /// Gets or sets the license for the property.
    /// </summary>
    public LicenseSettings License { get; set; }
}