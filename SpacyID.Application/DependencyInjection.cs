using Microsoft.Extensions.DependencyInjection;
using SpacyID.Application.Interfaces;
using SpacyID.Application.Interfaces.Services;
using SpacyID.Application.Services;

namespace SpacyID.Application;

public static class DependencyInjection
{
    public static IServiceCollection RegisterApplicationLayer(
        this IServiceCollection services)
    { 
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
