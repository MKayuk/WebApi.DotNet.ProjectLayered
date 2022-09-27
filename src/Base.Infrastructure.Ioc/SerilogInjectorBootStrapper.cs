using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Base.Infrastructure.Ioc
{
    public static class SerilogInjectorBootStrapper
    {
        public static IApplicationBuilder RegisterSerilog(this IApplicationBuilder app, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(configuration)
                    .Enrich.WithProperty("Environment", configuration["Logstash:Environment"])
                    .Enrich.WithProperty("ServiceName", configuration["Logstash:ServiceName"])
                    .Enrich.WithProperty("Project", configuration["Logstash:ServiceName"])
                    .CreateLogger();

            return app;
        }
    }
}
