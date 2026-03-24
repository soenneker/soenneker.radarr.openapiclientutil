using Soenneker.Radarr.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Radarr.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class RadarrOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IRadarrOpenApiClientUtil _openapiclientutil;

    public RadarrOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IRadarrOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
