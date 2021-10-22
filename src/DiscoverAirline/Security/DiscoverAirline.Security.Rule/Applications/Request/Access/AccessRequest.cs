using System.ComponentModel.DataAnnotations;

namespace DiscoverAirline.Security.Rule.Applications.Request.Access
{
    public class AccessCreateRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }

    }
    public class AccessUpdateRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }
    }
}
