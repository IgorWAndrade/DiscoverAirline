using System.ComponentModel.DataAnnotations;

namespace DiscoverAirline.Security.API.Application.ViewModels
{
    public class ClaimViewModel
    {
        [Required]
        public string Controller { get; set; }

        [Required]
        public string[] Actions { get; set; }
    }

    public class ClaimPutViewModel
    {
        [Required]
        public string Controller { get; set; }

        [Required]
        public string Action { get; set; }
    }
}
