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
    /// Executes the warmup operation.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    ValueTask Warmup(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves screen information such as width, height, pixel ratio, orientation, and user agent.
    /// </summary>
    ValueTask<ScreenInfoDto> Get(CancellationToken cancellationToken = default);
}
