using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Base.Application;
using Base.Application.Interface;
using Base.Infrastructure.Data.Repository;
using Base.Infrastructure.Data.Repository.Interface;
using Util.Notification;
using Util.Notification.Handlers;
using Util.Notification.Models;

namespace Base.Infrastructure.Ioc
{
    public static class NativeInjectorBootStrapper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            // Notification
            services.AddScoped<INotificationHandler<MyNotification>, NotifiyHandler>();
            services.AddScoped<INotify, Notify>();

            // Application
            services.AddScoped<IBaseAppService, BaseAppService>();

            // Specification

            // Repository
            services.AddScoped<IBaseRepository, BaseRepository>();

            return services;
        }
    }
}
