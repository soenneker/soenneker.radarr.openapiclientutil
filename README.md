[![](https://img.shields.io/nuget/v/soenneker.radarr.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.radarr.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.radarr.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.radarr.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.radarr.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.radarr.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.radarr.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.radarr.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Radarr.OpenApiClientUtil

Provides a lazily initialized Radarr client for movies, calendars, queues, downloads, indexers, quality profiles, commands, and system resources.

## Installation

```bash
dotnet add package Soenneker.Radarr.OpenApiClientUtil
```

## Configuration

```json
{
  "Radarr": {
    "ClientBaseUrl": "http://localhost:7878",
    "ApiKey": "your-radarr-api-key"
  }
}
```

`ClientBaseUrl` defaults to `http://localhost:7878`. Find the API key in Radarr under **Settings → General → Security**.

## Usage

```csharp
using Soenneker.Radarr.OpenApiClientUtil.Abstract;
using Soenneker.Radarr.OpenApiClientUtil.Registrars;

services.AddRadarrOpenApiClientUtilAsSingleton();

public sealed class RadarrStatusService
{
    private readonly IRadarrOpenApiClientUtil _radarr;

    public RadarrStatusService(IRadarrOpenApiClientUtil radarr)
    {
        _radarr = radarr;
    }

    public async Task GetStatus(CancellationToken cancellationToken)
    {
        var client = await _radarr.Get(cancellationToken);
        var status = await client.Api.V3.System.Status.GetAsync(
            cancellationToken: cancellationToken);
    }
}
```

Use `AddRadarrOpenApiClientUtilAsScoped()` when each scope should have its own lazily initialized API client. Both registrations reuse the singleton authenticated HTTP client provider.
