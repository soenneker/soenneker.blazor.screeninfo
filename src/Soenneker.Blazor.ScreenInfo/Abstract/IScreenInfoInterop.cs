using Soenneker.Blazor.ScreenInfo.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Blazor.ScreenInfo.Abstract;

/// <summary>
/// Defines the screen info interop contract.
/// </summary>
public interface IScreenInfoInterop : IAsyncDisposable
{
    /// <summary>
    /// Warms up screen info for the screen info.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task that completes when warmup is complete.</returns>
    ValueTask Warmup(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves screen information such as width, height, pixel ratio, orientation, and user agent.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested screen Info Dto.</returns>
    ValueTask<ScreenInfoDto> Get(CancellationToken cancellationToken = default);
}
