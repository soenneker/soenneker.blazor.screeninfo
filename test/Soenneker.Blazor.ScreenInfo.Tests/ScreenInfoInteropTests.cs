using Soenneker.Blazor.ScreenInfo.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Blazor.ScreenInfo.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class ScreenInfoInteropTests : HostedUnitTest
{
    private readonly IScreenInfoInterop _interop;

    public ScreenInfoInteropTests(Host host) : base(host)
    {
        _interop = Resolve<IScreenInfoInterop>(true);
    }

    [Test]
    public void Default()
    {

    }
}
