using Soenneker.Radarr.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Radarr.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class RadarrOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IRadarrOpenApiClientUtil _openapiclientutil;

    public RadarrOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IRadarrOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
