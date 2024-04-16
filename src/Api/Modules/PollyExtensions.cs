namespace Smart.Admin.Template.RestApi.Api.Modules;

using Infrastructure.CrossCutting.Extensions;
using Polly.Registry;

internal static class PollyExtensions
{
    private const string DefaultHttpRetryStrategy = "DefaultHttpRetryStrategy";

    internal static IServiceCollection AddPolly(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IReadOnlyPolicyRegistry<string>>(provider =>
        {
            var registry = new PolicyRegistry
            {
                { DefaultHttpRetryStrategy, PolicyExtensions.BuildDefaultHttpRetryStrategy() },
            };
            return registry;
        });

        return serviceCollection;
    }
}