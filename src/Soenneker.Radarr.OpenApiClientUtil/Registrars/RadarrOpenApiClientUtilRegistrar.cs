using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Radarr.HttpClients.Registrars;
using Soenneker.Radarr.OpenApiClientUtil.Abstract;

namespace Soenneker.Radarr.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class RadarrOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="RadarrOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddRadarrOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddRadarrOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IRadarrOpenApiClientUtil, RadarrOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="RadarrOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddRadarrOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddRadarrOpenApiHttpClientAsSingleton()
                .TryAddScoped<IRadarrOpenApiClientUtil, RadarrOpenApiClientUtil>();

        return services;
    }
}
