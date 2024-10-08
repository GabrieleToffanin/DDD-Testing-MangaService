﻿using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MangaPlanetto.ServiceDefaults;
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
                cfg.Host(connectionString ?? string.Empty);

                //"amqp://guest:1bqMUY72jFjP3E19tUUZ4x@localhost:57229"



                rabbitConfig(ctx, cfg);
            });
        });

        return services;
    }
}
