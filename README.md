[![](https://img.shields.io/nuget/v/soenneker.blazor.screeninfo.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.screeninfo/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.screeninfo/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.screeninfo/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.blazor.screeninfo.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.screeninfo/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.screeninfo/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.screeninfo/actions/workflows/codeql.yml)

# Soenneker.Blazor.ScreenInfo

A small Blazor JS interop library for reading the browser's current viewport, orientation, pixel ratio, touch support, and user agent.

## Installation

```bash
dotnet add package Soenneker.Blazor.ScreenInfo
```

Register the interop service in `Program.cs`:

```csharp
using Soenneker.Blazor.ScreenInfo.Registrars;

builder.Services.AddScreenInfoInteropAsScoped();
```

## Usage

Inject `IScreenInfoInterop` into an interactive component and call `Get()` after the component is rendered:

```razor
@using Soenneker.Blazor.ScreenInfo.Abstract
@using Soenneker.Blazor.ScreenInfo.Dtos
@inject IScreenInfoInterop ScreenInfo

<p>Viewport: @_screenInfo?.Width × @_screenInfo?.Height</p>
<p>Orientation: @_screenInfo?.Orientation</p>

@code {
    private ScreenInfoDto? _screenInfo;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender)
            return;

        _screenInfo = await ScreenInfo.Get();
        StateHasChanged();
    }
}
```

`Get()` returns a snapshot. It does not subscribe to resize or orientation events, so call it again whenever your application needs refreshed values.

## Returned values

| Property | Meaning |
| --- | --- |
| `Width`, `Height` | Current browser viewport dimensions in CSS pixels, not the physical display resolution. |
| `DevicePixelRatio` | Ratio between device pixels and CSS pixels. |
| `IsLandscape` | `true` when the viewport width is greater than its height. |
| `Orientation` | The Screen Orientation API value when available; otherwise `landscape` or `portrait`. |
| `IsTouchDevice` | A best-effort check based on touch events and `navigator.maxTouchPoints`. |
| `UserAgent` | The browser-provided user-agent string. |

`Warmup()` can be used to load the JavaScript module before the first `Get()` call when avoiding first-use import latency matters.

## Browser and security notes

- Browser interop is unavailable during static server rendering or prerendering. Call the service only after an interactive render.
- Touch detection does not prove that touch is the user's primary input method. Design controls to work with mouse, keyboard, and touch.
- User-agent strings can be reduced, spoofed, or changed. Do not use `UserAgent` for authorization, security decisions, or capability detection.
- Screen and user-agent data can contribute to browser fingerprinting. Collect or transmit it only when your privacy policy permits it.
