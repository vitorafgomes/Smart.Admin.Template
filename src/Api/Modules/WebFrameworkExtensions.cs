namespace Smart.Admin.Template.RestApi.Api.Modules;

using System.Text.Json.Serialization;
using Filters;
using ToolBox.Framework.Serializer.JsonCore.Converter;

internal static class WebFrameworkExtensions
{
    internal static IServiceCollection AddWebFramework(this IServiceCollection services)
    {
        services
            .AddRouting(options =>
            {
                options.LowercaseUrls = true;
            })
            .AddControllers(options =>
            {
                options.Filters.Add<CustomModelValidator>();
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter          = true;
                options.SuppressInferBindingSourcesForParameters = true;
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.Converters.Add(new ExceptionConverter<Exception>());
            });

        services.AddHttpContextAccessor();

        return services;
        
    }
}