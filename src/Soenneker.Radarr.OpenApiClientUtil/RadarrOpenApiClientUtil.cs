using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Radarr.HttpClients.Abstract;
using Soenneker.Radarr.OpenApiClientUtil.Abstract;
using Soenneker.Radarr.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Radarr.OpenApiClientUtil;

public sealed class RadarrOpenApiClientUtil : IRadarrOpenApiClientUtil
{
    private readonly AsyncSingleton<RadarrOpenApiClient> _client;

    public RadarrOpenApiClientUtil(IRadarrOpenApiHttpClient httpClientUtil, IConfiguration _)
    {
        _client = new AsyncSingleton<RadarrOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient)
            {
                BaseUrl = httpClient.BaseAddress!.ToString().TrimEnd('/')
            };

            return new RadarrOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<RadarrOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
