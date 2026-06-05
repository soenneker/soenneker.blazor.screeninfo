using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Blazor.ScreenInfo.Abstract;
using Soenneker.Blazor.Utils.ModuleImport.Registrars;

namespace Soenneker.Blazor.ScreenInfo.Registrars;

/// <summary>
/// Represents the screen info registrar.
/// </summary>
public static class ScreenInfoRegistrar
{
    /// <summary>
    /// Adds screen info interop as scoped.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The result of the operation.</returns>
    public static IServiceCollection AddScreenInfoInteropAsScoped(this IServiceCollection services)
    {
        services.AddModuleImportUtilAsScoped().TryAddScoped<IScreenInfoInterop, ScreenInfoInterop>();

        return services;
    }
}
