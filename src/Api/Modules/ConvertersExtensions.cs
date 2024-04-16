namespace Smart.Admin.Template.RestApi.Api.Modules;

using Microsoft.Extensions.DependencyInjection.Extensions;

internal static class ConvertersExtensions
{
    internal static IServiceCollection AddConverters(this IServiceCollection serviceCollection)
    {
 
        
        serviceCollection
            .TryAddSingleton<Infrastructure.CrossCutting.Errors.IOutputErrorConverter,
                Infrastructure.CrossCutting.Errors.OutputErrorConverter>();

        return serviceCollection;
    }
}