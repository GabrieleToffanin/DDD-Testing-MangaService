using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MangaPlanetto.Cms.Infrastructure.DependencyInjection;
public static class MassTransitInjectionExtensions
{
    public static IServiceCollection AddMassTransitWithRabbit(
        this IServiceCollection services,
        Action<IBusRegistrationConfigurator> massTransitBusConfiguration,
        Action<IBusRegistrationConfigurator, IRabbitMqBusFactoryConfigurator> rabbitConfig)
    {
        services.AddMassTransit(ctx =>
        {
            massTransitBusConfiguration(ctx);

            ctx.UsingRabbitMq((context, cfg) =>
            {
                var configService = context.GetRequiredService<IConfiguration>();
                string connectionString = configService.GetConnectionString("rabbitmq")!;
                cfg.Host(connectionString);

                rabbitConfig(ctx, cfg);
            });
        });

        return services;
    }
}
