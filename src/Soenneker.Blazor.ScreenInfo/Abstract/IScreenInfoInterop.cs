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
    /// Loads the JavaScript module so a later screen information request does not pay the module import cost.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task that completes when warmup is complete.</returns>
    ValueTask Warmup(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a snapshot of the current browser viewport, pixel ratio, orientation, touch support, and user agent.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result contains the current screen information.</returns>
    ValueTask<ScreenInfoDto> Get(CancellationToken cancellationToken = default);
}
