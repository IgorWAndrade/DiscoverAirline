using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscoverAirline.Security.Rule.Applications.Request.AuthorizationManager
{
    public class AuthManagersUsersRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Role { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public List<int> Users { get; set; }
    }
}
