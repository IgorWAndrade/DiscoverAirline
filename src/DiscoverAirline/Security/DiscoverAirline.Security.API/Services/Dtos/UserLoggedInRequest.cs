using System.ComponentModel.DataAnnotations;

namespace DiscoverAirline.Security.API.Services.Dtos
{
    public class UserLoggedInRequest
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
