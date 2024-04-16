namespace Smart.Admin.Template.RestApi.Api.Modules;

using Asp.Versioning.ApiExplorer;
using Infrastructure.CrossCutting.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

internal static class SwaggerExtensions
{
    internal static IServiceCollection AddSwagger(this IServiceCollection serviceCollection,
        SwaggerSettings applicationSettingsSwagger)
    {
        serviceCollection.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        serviceCollection.AddEndpointsApiExplorer();

        serviceCollection.AddSwaggerGen(options => options.DescribeAllParametersInCamelCase());

        return serviceCollection;
    }

    internal static IApplicationBuilder ConfigureSwagger(
        this IApplicationBuilder app,
        IReadOnlyList<ApiVersionDescription> provider)
    {
        app.UseSwagger()
            .UseSwaggerUI(options =>
            {
                foreach (var description in provider)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",description.GroupName.ToUpperInvariant());
                    
                    options.DocExpansion(DocExpansion.None);
                }
            }
        );

        return app;
    }

    internal class ConfigureSwaggerOptions(
        IApiVersionDescriptionProvider provider,
        ApplicationSettings applicationSettings)
        : IConfigureOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                var openApiInfo = new OpenApiInfo
                {
                    Title = applicationSettings.Swagger.Title,
                    Version = description.ApiVersion.ToString(),
                    Description = applicationSettings.Swagger.Description,
                    Contact = new OpenApiContact()
                    { 
                        Name = applicationSettings.Swagger.Contact.Name,
                        Email = applicationSettings.Swagger.Contact.Email,
                        Url = new Uri(applicationSettings.Swagger.Contact.Url),
                    },
                    License = new OpenApiLicense()
                    {
                        Name = applicationSettings.Swagger.License.Name,
                        Url = new Uri(applicationSettings.Swagger.License.Url),
                    },
                };

                options.SwaggerDoc(description.GroupName, openApiInfo);
            }
        }
    }
}