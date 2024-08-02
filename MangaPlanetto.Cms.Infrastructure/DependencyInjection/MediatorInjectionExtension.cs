using MangaPlanetto.Cms.Application.Manga;
using Microsoft.Extensions.DependencyInjection;

namespace MangaPlanetto.Cms.Infrastructure.DependencyInjection;

public static class MediatorInjectionExtension
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(typeof(PriceUpdatedEventHandler).Assembly);
        });

        return services;
    }
}
