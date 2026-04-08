using System.Threading;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Soenneker.Blazor.ScreenInfo.Abstract;
using Soenneker.Blazor.ScreenInfo.Dtos;
using Soenneker.Blazor.Utils.ModuleImport.Abstract;
using Soenneker.Extensions.CancellationTokens;
using Soenneker.Utils.CancellationScopes;

namespace Soenneker.Blazor.ScreenInfo;

///<inheritdoc cref="IScreenInfoInterop"/>
public sealed class ScreenInfoInterop : IScreenInfoInterop
{
    private readonly IModuleImportUtil _moduleImportUtil;

    private const string _modulePath = "_content/Soenneker.Blazor.ScreenInfo/js/screeninfointerop.js";

    private readonly CancellationScope _cancellationScope = new();

    public ScreenInfoInterop(IModuleImportUtil moduleImportUtil)
    {
        _moduleImportUtil = moduleImportUtil;
    }

    public async ValueTask Warmup(CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
            _ = await _moduleImportUtil.GetContentModuleReference(_modulePath, linked);
    }

    public async ValueTask<ScreenInfoDto> Get(CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
        {
            IJSObjectReference module = await _moduleImportUtil.GetContentModuleReference(_modulePath, linked);
            return await module.InvokeAsync<ScreenInfoDto>("get", linked);
        }
    }

    public async ValueTask DisposeAsync()
    {
        await _moduleImportUtil.DisposeContentModule(_modulePath);
        await _cancellationScope.DisposeAsync();
    }
}
