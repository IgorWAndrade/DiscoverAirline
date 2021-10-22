using System.ComponentModel.DataAnnotations;

namespace DiscoverAirline.Security.Rule.Applications.Request.Applications
{
    public class ApplicationCreateRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }
    }

    public class ApplicationUpdateRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }
    }
}
