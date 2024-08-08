using MangaPlanetto.Cms.Domain.Common;
using MangaPlanetto.Cms.Infrastructure.Messaging;
using MangaPlanetto.ServiceDefaults;
using Microsoft.Extensions.DependencyInjection;

namespace MangaPlanetto.Cms.Infrastructure.DependencyInjection;
public static class EventPublisherExtension
{
    public static IServiceCollection AddEventPublisher(this IServiceCollection services)
    {

        // through the AddMassTransitWithRabbit extension method, we can configure the RabbitMQ consumers
        services.AddMassTransitWithRabbit(
            cfg =>
            {

            },
            (ctx, cfg) =>
            {

            });

        services.AddSingleton<IEventPublisher, EventPublisher>();

        return services;
    }
}
