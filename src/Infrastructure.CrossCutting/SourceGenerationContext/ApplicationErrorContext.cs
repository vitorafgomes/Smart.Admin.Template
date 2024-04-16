namespace Smart.Admin.Template.RestApi.Infrastructure.CrossCutting.SourceGenerationContext;

using System.Text.Json.Serialization;
using ToolBox.Framework.Error;

[JsonSourceGenerationOptions(WriteIndented = true, PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, IncludeFields = true)]
[JsonSerializable(typeof(ApplicationError))]
public sealed partial class ApplicationErrorContext : JsonSerializerContext
{
}