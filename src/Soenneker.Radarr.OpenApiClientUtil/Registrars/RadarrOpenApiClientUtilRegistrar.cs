using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Radarr.HttpClients.Registrars;
using Soenneker.Radarr.OpenApiClientUtil.Abstract;

namespace Soenneker.Radarr.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the lazily initialized Radarr API client.
/// </summary>
public static class RadarrOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds the Radarr API client utility as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddRadarrOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddRadarrOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IRadarrOpenApiClientUtil, RadarrOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds the Radarr API client utility as a scoped service backed by the singleton HTTP client provider. <para/>
    /// </summary>
    public static IServiceCollection AddRadarrOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddRadarrOpenApiHttpClientAsSingleton()
                .TryAddScoped<IRadarrOpenApiClientUtil, RadarrOpenApiClientUtil>();

        return services;
    }
}
