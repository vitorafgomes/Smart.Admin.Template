namespace Smart.Admin.Template.RestApi.Infrastructure.CrossCutting.Extensions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

/// <summary>
/// Provides extension methods for decorating services in an IServiceCollection.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Decorates the factory method for a given service type with a decorator function.
    /// </summary>
    /// <typeparam name="T">The type of the service to decorate.</typeparam>
    /// <param name="serviceCollection">The service collection.</param>
    /// <param name="decorator">The decorator function that takes an <see cref="IServiceProvider"/> and the original service instance as arguments and returns a decorated service instance.</param>
    /// <returns>The modified service collection with the decorated factory method.</returns>
    public static IServiceCollection DecorateFactory<T>(this IServiceCollection serviceCollection,
        Func<IServiceProvider, T, T> decorator)
    {
        var originalDescriptor = GetServiceDescriptor<T>(serviceCollection);
        var decoratedDescriptor = CreateDecoratedServiceDescriptor(originalDescriptor, decorator);
        ReplaceWithDecoratedServiceDescriptor(serviceCollection, decoratedDescriptor);
        return serviceCollection;
    }

    /// <summary>
    /// Gets the ServiceDescriptor for the specified type from the given IServiceCollection.
    /// </summary>
    /// <typeparam name="T">The type of service.</typeparam>
    /// <param name="serviceCollection">The IServiceCollection instance.</param>
    /// <returns>The ServiceDescriptor for the specified type.</returns>
    private static ServiceDescriptor GetServiceDescriptor<T>(IServiceCollection serviceCollection)
    {
        return serviceCollection.First(x => x.ServiceType == typeof(T));
    }

    /// <summary>
    /// Create a new decorated service descriptor based on the original descriptor and a decorator function.
    /// </summary>
    /// <param name="originalDescriptor">The original service descriptor to decorate.</param>
    /// <param name="decorator">The decorator function that takes an <see cref="IServiceProvider"/> and the original service instance, and returns the decorated service instance.</param>
    /// <typeparam name="T">The type of the service being decorated.</typeparam>
    /// <returns>A new <see cref="ServiceDescriptor"/> representing the decorated service.</returns>
    private static ServiceDescriptor CreateDecoratedServiceDescriptor<T>(ServiceDescriptor originalDescriptor,
        Func<IServiceProvider, T, T> decorator)
    {
        return ServiceDescriptor.Describe(
            originalDescriptor.ServiceType, 
            provider => DecorateServiceInstance(provider, originalDescriptor, decorator), 
            originalDescriptor.Lifetime
        );
    }

    /// <summary>
    /// Decorates a service instance with the provided decorator.
    /// </summary>
    /// <typeparam name="T">The type of the service instance.</typeparam>
    /// <param name="provider">The service provider.</param>
    /// <param name="descriptor">The service descriptor.</param>
    /// <param name="decorator">The decorator function that accepts the service provider and the original service instance and returns the decorated service instance.</param>
    /// <returns>The decorated service instance.</returns>
    private static T DecorateServiceInstance<T>(IServiceProvider provider, ServiceDescriptor descriptor,
        Func<IServiceProvider, T, T> decorator)
    {
        var originalFactory = (T)descriptor.ImplementationFactory(provider);
        return decorator(provider, originalFactory);
    }

    /// <summary>
    /// Replaces a service descriptor in the service collection with a decorated service descriptor.
    /// </summary>
    /// <param name="serviceCollection">The service collection.</param>
    /// <param name="descriptor">The original service descriptor to replace.</param>
    private static void ReplaceWithDecoratedServiceDescriptor(IServiceCollection serviceCollection,
        ServiceDescriptor descriptor)
    {
        serviceCollection.Replace(descriptor);
    }
}