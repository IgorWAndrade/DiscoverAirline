using DiscoverAirline.CoreAPI.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace DiscoverAirline.CoreAPI.Extensions
{
    public static class SecurityPoliciesExtension
    {
        public static IServiceCollection AddSecurityPoliciesServices(this IServiceCollection services, IList<PolicySecurity> policies)
        {
            services.AddAuthorization(x =>
            {
                foreach (var item in policies)
                {
                    foreach (var claim in item.Claims)
                    {
                        x.AddPolicy(BuildPolicyName(claim.Controller, claim.Action), policy =>
                         {
                             policy.RequireRole(item.Service);
                             policy.RequireClaim(claim.Controller);
                             policy.RequireClaim(claim.Action);
                         });
                    }
                }
            });

            return services;
        }

        public static string BuildPolicyName(string controller, string action) => string.Format("{0}:{1}", controller, action);
    }
}
