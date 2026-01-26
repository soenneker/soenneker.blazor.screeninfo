using System.Threading;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Soenneker.Asyncs.Initializers;
using Soenneker.Blazor.ScreenInfo.Abstract;
using Soenneker.Blazor.ScreenInfo.Dtos;
using Soenneker.Blazor.Utils.ResourceLoader.Abstract;
using Soenneker.Extensions.CancellationTokens;
using Soenneker.Utils.CancellationScopes;

namespace Soenneker.Blazor.ScreenInfo;

///<inheritdoc cref="IScreenInfoInterop"/>
public sealed class ScreenInfoInterop : IScreenInfoInterop
{
    private readonly IJSRuntime _jsRuntime;
    private readonly IResourceLoader _resourceLoader;

    private readonly AsyncInitializer _scriptInitializer;

    private const string _modulePath = "Soenneker.Blazor.ScreenInfo/js/screeninfointerop.js";
    private const string _moduleNamespace = "ScreenInfoInterop";

    private readonly CancellationScope _cancellationScope = new();

    public ScreenInfoInterop(IJSRuntime jSRuntime, IResourceLoader resourceLoader)
    {
        _jsRuntime = jSRuntime;
        _resourceLoader = resourceLoader;
        _scriptInitializer = new AsyncInitializer(InitializeScript);
    }

    private ValueTask InitializeScript(CancellationToken token)
    {
        return _resourceLoader.ImportModuleAndWaitUntilAvailable(_modulePath, _moduleNamespace, 100, token);
    }

    public ValueTask Warmup(CancellationToken cancellationToken = default)
    {
        var linked = _cancellationScope.CancellationToken.Link(cancellationToken, out var source);

        using (source)
            return _scriptInitializer.Init(linked);
    }

    public async ValueTask<ScreenInfoDto> Get(CancellationToken cancellationToken = default)
    {
        var linked = _cancellationScope.CancellationToken.Link(cancellationToken, out var source);

        using (source)
        {
            await _scriptInitializer.Init(linked);
            return await _jsRuntime.InvokeAsync<ScreenInfoDto>("ScreenInfoInterop.get", linked);
        }
    }

    public async ValueTask DisposeAsync()
    {
        await _resourceLoader.DisposeModule(_modulePath);
        await _scriptInitializer.DisposeAsync();
        await _cancellationScope.DisposeAsync();
    }
}
