using DiscoverAirline.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace DiscoverAirline.CoreAPI
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CoreController : ControllerBase
    {
        protected readonly ILogger<CoreController> Logger;
        protected Notification Notification = new Notification();

        public CoreController(ILogger<CoreController> logger)
        {
            this.Logger = logger;
        }

        protected ActionResult CustomResponse(Notification notification = null)
        {
            if (notification != null)
            {
                Notification = notification;
            }

            if (Notification.IsValid())
            {
                return Ok(Notification.Get());
            }
            return BadRequest(Notification.Get());
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                Notification.AddError(erro.ErrorMessage);
            }

            return CustomResponse();
        }
    }
}
