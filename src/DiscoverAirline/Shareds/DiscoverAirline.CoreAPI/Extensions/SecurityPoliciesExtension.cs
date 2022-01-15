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
                        x.AddPolicy(BuildPolicyName(claim), policy =>
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

        private static string BuildPolicyName(ClaimSecurity item) => string.Format("{0}:{1}", item.Controller, item.Action);
    }
}
