using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Base.Infrastructure.Data.Repository.SeedWork;
using Base.Infrastructure.Data.Repository.SeedWork.Interface;

namespace Base.Infrastructure.Ioc.Data
{
    public static class MongoInjectorBootStrapper
    {
        public static IServiceCollection RegisterMongoDBContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IMongoConnection>(_ =>
            {
                return new MongoConnection(config);
            });

            services.AddScoped<IMongoContext, MongoContext<IMongoConnection>>();

            return services;
        }
    }
}
