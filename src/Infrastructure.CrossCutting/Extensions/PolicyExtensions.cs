namespace Smart.Admin.Template.RestApi.Infrastructure.CrossCutting.Extensions;

using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;
using Polly.Registry;
using Polly.Retry;

/// <summary>
/// Contains extension methods for working with policies.
/// </summary>
public static class PolicyExtensions
{
    /// <summary>
    /// Adds a policy to the service collection.
    /// </summary>
    /// <param name="serviceCollection">The service collection.</param>
    /// <param name="key">The key to associate with the policy.</param>
    /// <param name="factory">A function that returns an instance of <see cref="IsPolicy"/> based on the provided <see cref="IServiceProvider"/>.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddPolicy(this IServiceCollection serviceCollection, string key,
        Func<IServiceProvider, IsPolicy> factory)
    {
        serviceCollection.DecorateFactory<IReadOnlyPolicyRegistry<string>>((provider, readOnlyPolicyRegistry) =>
        {
            var policyRegistry = readOnlyPolicyRegistry as IPolicyRegistry<string>;

            policyRegistry.Add(key, factory(provider));

            return policyRegistry;
        });

        return serviceCollection;
    }

    /// <summary>
    /// Builds the default HTTP retry strategy.
    /// </summary>
    /// <remarks>
    /// This method constructs and returns an <see cref="AsyncRetryPolicy"/> object that can be used for handling transient HTTP errors and implementing a retry mechanism.
    /// </remarks>
    /// <returns>
    /// An <see cref="AsyncRetryPolicy{TResult}"/> object representing the default HTTP retry strategy.
    /// </returns>
    public static AsyncRetryPolicy<HttpResponseMessage> BuildDefaultHttpRetryStrategy()
    {
        var delay = Backoff.ExponentialBackoff(TimeSpan.FromMilliseconds(50), retryCount: 3);

        var policy = HttpPolicyExtensions.HandleTransientHttpError().WaitAndRetryAsync(delay);

        return policy;
    }
}