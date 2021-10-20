using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscoverAirline.Security.Rule.Applications.Request.AuthorizationManager
{
    public class AuthManagerRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int ServiceId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int ControllerId { get; set; }

        public List<int> Actions { get; set; }
    }
}
