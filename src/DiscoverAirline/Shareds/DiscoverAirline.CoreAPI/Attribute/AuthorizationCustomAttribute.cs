using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
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
        public AuthorizationCustomAttribute(string controller, string role, string action) : base(typeof(AuthorizationCustomFilter))
        {
            var profileJson = new
            {
                Controller = controller,
                Role = role,
                Action = action
            };
            Arguments = new object[] { new Claim(role, JsonConvert.SerializeObject(profileJson)) };
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
            var hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == _claim.Type && c.Value == _claim.Value);
            if (!hasClaim)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
