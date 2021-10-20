using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscoverAirline.Security.Rule.Applications.Request.AuthorizationManager
{
    public class AuthManagersRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public List<AuthManagerServicesRequest> Services { get; set; }

    }

    public class AuthManagerServicesRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int ServiceId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public List<AuthManagerControllersRequest> Controllers { get; set; }
    }

    public class AuthManagerControllersRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Controller { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public List<int> Actions { get; set; }
    }
}
