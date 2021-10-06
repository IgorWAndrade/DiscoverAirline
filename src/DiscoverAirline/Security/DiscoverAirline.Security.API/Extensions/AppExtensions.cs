using DiscoverAirline.CoreBroker;
using DiscoverAirline.CoreBroker.Abstractions;
using DiscoverAirline.Security.API.Core.Services;
using DiscoverAirline.Security.API.Services;
using DiscoverAirline.Security.API.Services.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DiscoverAirline.Security.API.Application.Extensions
{
    public static class AppExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddSingleton<IEventBus, EventBus>();
            services.AddSingleton<IEventBusPub, EventBusPub>();

            return services;
        }

        public static IApplicationBuilder UseAppServices(this IApplicationBuilder app)
        {
            return app;
        }

        private static bool Handler(dynamic arg)
        {
            throw new NotImplementedException();
        }
    }
}
