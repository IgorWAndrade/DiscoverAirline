using System.ComponentModel.DataAnnotations;

namespace DiscoverAirline.Security.Rule.Applications.Request.Actions
{
    public class ActionRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public EAction Action { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int ControllerId { get; set; }
    }

    public enum EAction
    {
        Get,
        Post,
        Put,
        Patch,
        Delete
    }
}
