namespace Smart.Admin.Template.RestApi.Api.Modules;

internal static class VersioningExtensions
{
    internal static IServiceCollection AddVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(
                options => { options.ReportApiVersions = true; })
            .AddMvc()
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
                options.FormatGroupName = (group, version) => $"{group} - {version}";
            });

        return services;
    }
}