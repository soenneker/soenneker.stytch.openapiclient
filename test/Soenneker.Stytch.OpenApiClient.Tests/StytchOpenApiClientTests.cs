using Soenneker.Tests.HostedUnit;

namespace Soenneker.Stytch.OpenApiClient.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class StytchOpenApiClientTests : HostedUnitTest
{
    public StytchOpenApiClientTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
