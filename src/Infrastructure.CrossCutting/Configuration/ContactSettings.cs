namespace Smart.Admin.Template.RestApi.Infrastructure.CrossCutting.Configuration;

/// <summary>
/// Represents a contact with email, URL, and name.
/// </summary>
public sealed class ContactSettings
{
    /// <summary>
    /// Gets or sets the email address.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the URL property.
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// Gets or sets the name of the property.
    /// </summary>
    public string Name { get; set; }
}