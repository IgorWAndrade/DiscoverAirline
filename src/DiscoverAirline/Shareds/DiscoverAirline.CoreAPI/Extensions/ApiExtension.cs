﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DiscoverAirline.CoreAPI.Extensions
{
    public static class ApiExtension
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSecurityServices(configuration);

            services.AddControllers();

            services.AddHealthCheckServices(configuration);

            services.AddCors(o => o.AddPolicy("FreeUse", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            return services;
        }

        public static IApplicationBuilder UseApi(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("FreeUse");
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSecurity();

            app.UseEndpoints(endPoint =>
            {
                endPoint.MapControllers();
            });

            app.UseHealthCheck();

            return app;
        }
    }
}
