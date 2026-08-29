[![](https://img.shields.io/nuget/v/soenneker.blazor.screeninfo.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.screeninfo/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.screeninfo/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.screeninfo/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.blazor.screeninfo.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.screeninfo/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.screeninfo/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.screeninfo/actions/workflows/codeql.yml)

# Soenneker.Blazor.ScreenInfo

Defines the screen info interop contract.

## Install

```bash
dotnet add package Soenneker.Blazor.ScreenInfo
```

## Quick start

```csharp
using Soenneker.Blazor.ScreenInfo.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddScreenInfoInteropAsScoped();
```

Registers Screen Info Interop with a scoped lifetime.

## What you get

- `IScreenInfoInterop` — Defines the screen info interop contract.
- `ScreenInfoRegistrar` — Represents the screen info registrar.
- `ScreenInfoDto` — Represents the screen info dto record.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IScreenInfoInterop.Get(cancellationToken)` | Retrieves screen information such as width, height, pixel ratio, orientation, and user agent. | A task whose result is the requested screen Info Dto. |
| `ScreenInfoRegistrar.AddScreenInfoInteropAsScoped(services)` | Registers Screen Info Interop with a scoped lifetime. | The same service collection, so additional registrations can be chained. |
| `ScreenInfoDto.Width` | Gets or sets width. | Gets or sets width. |
| `ScreenInfoDto.Height` | Gets or sets height. | Gets or sets height. |
| `ScreenInfoDto.DevicePixelRatio` | Gets or sets device pixel ratio. | Gets or sets device pixel ratio. |
| `ScreenInfoDto.IsLandscape` | Gets or sets a value indicating whether the instance is landscape. | Gets or sets a value indicating whether the instance is landscape. |
| `ScreenInfoDto.Orientation` | Gets or sets orientation. | Gets or sets orientation. |
| `ScreenInfoDto.IsTouchDevice` | Gets or sets a value indicating whether the instance is touch device. | Gets or sets a value indicating whether the instance is touch device. |
| `ScreenInfoDto.UserAgent` | Gets or sets user agent. | Gets or sets user agent. |

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
- Dispose instances you own when their scope ends so held resources can be released.
