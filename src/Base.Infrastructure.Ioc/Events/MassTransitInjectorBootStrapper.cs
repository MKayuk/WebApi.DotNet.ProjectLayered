using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Base.Infrastructure.Ioc.Events
{
    public static class MassTransitInjectorBootStrapper
    {
        public static IServiceCollection RegisterEvents(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(configurator =>
            {
                // TODO: Set consumers
                // configurator.AddConsumer<TConsumer>();

                configurator.UsingRabbitMq((context, config) =>
                {
                    config.Host(configuration["EventBus:Host"], configuration["EventBus:VirtualHost"], host =>
                    {
                        host.Username(configuration["EventBus:User"]);
                        host.Password(configuration["EventBus:Pwd"]);
                    });

                    // TODO: Bind consumers

                    // queue name = "base:entity_changed_listener"
                    // exchange name = "Events:EntityChanged"
                    // TConsumer = message's contract exchanged

                    //config.ReceiveEndpoint("base:entity_changed_listener", e =>
                    //{
                    //    e.Bind("Events:EntityChanged");
                    //    e.ConfigureConsumer<TConsumer>(context);
                    //});
                });
            });

            services.AddMassTransitHostedService();

            return services;
        }
    }
}
