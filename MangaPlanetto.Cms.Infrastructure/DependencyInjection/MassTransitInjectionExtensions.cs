using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MangaPlanetto.Cms.Infrastructure.DependencyInjection;
public static class MassTransitInjectionExtensions
{
    public static IServiceCollection AddEventPublisher(this IServiceCollection services)
    {
        services.AddMassTransit(ctx =>
        {
            ctx.UsingRabbitMq((context, cfg) =>
            {
                var configService = context.GetRequiredService<IConfiguration>();
                string connectionString = configService.GetConnectionString("rabbitmq")!;
                cfg.Host(connectionString);
            });
        });

        return services;
    }
}
