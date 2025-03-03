using Soenneker.Blazor.ScreenInfo.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Blazor.ScreenInfo.Tests;

[Collection("Collection")]
public class ScreenInfoInteropTests : FixturedUnitTest
{
    private readonly IScreenInfoInterop _interop;

    public ScreenInfoInteropTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _interop = Resolve<IScreenInfoInterop>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
