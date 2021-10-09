using System.ComponentModel.DataAnnotations;

namespace DiscoverAirline.Security.API.Application.Dtos
{
    public class UserLoggedInRequest
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
