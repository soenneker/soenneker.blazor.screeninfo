using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Blazor.ScreenInfo.Abstract;
using Soenneker.Blazor.Utils.ModuleImport.Registrars;

namespace Soenneker.Blazor.ScreenInfo.Registrars;

public static class ScreenInfoRegistrar
{
    public static IServiceCollection AddScreenInfoInteropAsScoped(this IServiceCollection services)
    {
        services.AddModuleImportUtilAsScoped().TryAddScoped<IScreenInfoInterop, ScreenInfoInterop>();

        return services;
    }
}
