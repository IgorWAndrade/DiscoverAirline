using System.ComponentModel.DataAnnotations;

namespace DiscoverAirline.Security.Rule.Applications.Request
{
    public class RoleCreateRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }
    }
}
