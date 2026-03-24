using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Radarr.HttpClients.Abstract;
using Soenneker.Radarr.OpenApiClientUtil.Abstract;
using Soenneker.Radarr.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Radarr.OpenApiClientUtil;

///<inheritdoc cref="IRadarrOpenApiClientUtil"/>
public sealed class RadarrOpenApiClientUtil : IRadarrOpenApiClientUtil
{
    private readonly AsyncSingleton<RadarrOpenApiClient> _client;

    public RadarrOpenApiClientUtil(IRadarrOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<RadarrOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Radarr:ApiKey");
            string authHeaderValueTemplate = configuration["Radarr:AuthHeaderValueTemplate"] ?? "{token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

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
