using Soenneker.Radarr.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Radarr.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IRadarrOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<RadarrOpenApiClient> Get(CancellationToken cancellationToken = default);
}
