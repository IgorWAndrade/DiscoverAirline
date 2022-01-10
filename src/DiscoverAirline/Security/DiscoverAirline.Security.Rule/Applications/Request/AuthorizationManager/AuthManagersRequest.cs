using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscoverAirline.Security.Rule.Applications.Request.AuthorizationManager
{
    public class AuthManagersRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public List<AuthManagerServicesRequest> Applications { get; set; }

    }

    public class AuthManagerServicesRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int ApplicationId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public List<AuthManagerAccessRequest> Access { get; set; }
    }

    public class AuthManagerAccessRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int AccessId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public List<int> Actions { get; set; }
    }
}
