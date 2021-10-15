using DiscoverAirline.CoreAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Security.Claims;

namespace DiscoverAirline.CoreAPI.Attribute
{
    public class AuthorizationCustomAttribute : TypeFilterAttribute
    {
        /// <summary>
        /// This Attribute was created by authorization in this Architecture All
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="role"></param>
        /// <param name="action"></param>
        public AuthorizationCustomAttribute(string service, string controller, string action) : base(typeof(AuthorizationCustomFilter))
        {
            var profileJson = new ProfileAuthorization
            {
                Controller = controller,
                Service = service,
                Action = action
            };
            Arguments = new object[] { new Claim(profileJson.Service, JsonConvert.SerializeObject(profileJson)) };
        }
    }

    public class AuthorizationCustomFilter : IAuthorizationFilter
    {
        readonly Claim _claim;

        public AuthorizationCustomFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var securityClaim = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Security");
            if (securityClaim == null)
            {
                context.Result = new ForbidResult();
            }
            else
            {
                var profile = CodificationUtil.Base64Decode(securityClaim.Value);
                IsAuthorize(profile, context);
            }
        }

        private void IsAuthorize(Models.UserProfile profile, AuthorizationFilterContext context)
        {
            var service = profile.Services.FirstOrDefault(x => x.Name == _claim.Type);
            if (service != null)
            {
                var permission = JsonConvert.DeserializeObject<ProfileAuthorization>(_claim.Value);
                var validated = false;
                foreach (var controller in service.Controllers)
                {
                    if (controller.Name == permission.Controller && controller.Actions.Any(x => x.Equals(permission.Action)))
                    {
                        validated = true;
                    }
                }

                if (!validated)
                {
                    context.Result = new ForbidResult();
                }
            }
            else
            {
                context.Result = new ForbidResult();
            }
        }
    }

    internal class ProfileAuthorization
    {
        public string Service { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
