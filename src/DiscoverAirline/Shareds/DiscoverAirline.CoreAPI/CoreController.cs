using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DiscoverAirline.CoreAPI
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CoreController : ControllerBase
    {

        protected string CustomResponse(object response)
        {
            return JsonConvert.SerializeObject(response, Formatting.Indented);
        }
    }
}
