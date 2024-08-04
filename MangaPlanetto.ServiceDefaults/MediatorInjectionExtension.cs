using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MangaPlanetto.ServiceDefaults;

public static class MediatorInjectionExtension
{
    public static IServiceCollection AddMediator(
        this IServiceCollection services,
        Assembly handlersAssembly)
    {
        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(handlersAssembly);
        });

        return services;
    }
}
