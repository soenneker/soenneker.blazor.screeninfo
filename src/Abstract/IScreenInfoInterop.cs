using Soenneker.Blazor.ScreenInfo.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Blazor.ScreenInfo.Abstract;

public interface IScreenInfoInterop : IAsyncDisposable
{
    ValueTask Warmup(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves screen information such as width, height, pixel ratio, orientation, and user agent.
    /// </summary>
    ValueTask<ScreenInfoDto> Get(CancellationToken cancellationToken = default);
}
