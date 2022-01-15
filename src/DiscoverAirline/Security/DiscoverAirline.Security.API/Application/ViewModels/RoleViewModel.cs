using System.ComponentModel.DataAnnotations;

namespace DiscoverAirline.Security.API.Application.ViewModels
{
    public class RoleViewModel
    {
        [Required]
        public string Name { get; set; }
        public string NormalizedName { get; set; } = "";
    }
}
