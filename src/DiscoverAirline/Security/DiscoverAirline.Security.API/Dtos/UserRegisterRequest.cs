using System.ComponentModel.DataAnnotations;

namespace DiscoverAirline.Security.API.Models
{
    public class UserRegisterRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas não conferem.")]
        public string PasswordConfirmation { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public UserAddressRequest Address { get; set; }
    }

    public class UserAddressRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Number { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Street { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string District { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string City { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string ZipCode { get; set; }
    }
}
