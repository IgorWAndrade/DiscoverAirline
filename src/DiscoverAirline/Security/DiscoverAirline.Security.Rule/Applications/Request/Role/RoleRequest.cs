using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscoverAirline.Security.Rule.Applications.Request.Role
{
    public class RoleCreateRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }

        public string BusinessName { get; set; } = "";
    }

    public class RoleUpdateRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }

        public string BusinessName { get; set; } = "";
    }

    public class RoleAttachUsersRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public List<int> Users { get; set; }

    }

    public class RoleDetachUsersRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public List<int> Users { get; set; }
    }
}
