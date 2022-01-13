using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DiscoverAirline.Security.API.Rules.ViewModels
{
    public class UsuarioRegistro
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
        public string SenhaConfirmacao { get; set; }
    }

    public class UsuarioLogin
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Senha { get; set; }
    }

    public class UsuarioRespostaLogin
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UsuarioToken UsuarioToken { get; set; }
    }

    public class UsuarioToken
    {
        public string Id { get; set; }
        public string UserEmail { get; set; }
        public string TokenTypeAccess { get; set; }
        public string TokenCode { get; set; }
        public string TokenRefreshCode { get; set; }
        public DateTime TokenValidTo { get; set; }
        public DateTime TokenValidFrom { get; set; }
        public DateTime TokenRefreshExiration { get; set; }
        public IEnumerable<UsuarioClaim> Claims { get; set; }
        public static UsuarioToken Generate(IdentityUser user, UserRefreshToken tokenRefresh, string token, DateTime validTo, DateTime validFrom)
        {
            return new UsuarioToken
            {
                Id = user.Id,
                UserEmail = user.Email,
                TokenCode = token,
                TokenTypeAccess = "Bearer",
                TokenValidTo = validTo,
                TokenValidFrom = validFrom,
                TokenRefreshCode = tokenRefresh.Token,
                TokenRefreshExiration = tokenRefresh.ExpiryDate
            };
        }
    }

    public class UserRefreshToken
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public virtual IdentityUser User { get; set; }

        public static string GenerateToken()
        {
            return RandomString(25) + Guid.NewGuid();
        }

        private static string RandomString(int length)
        {
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }

    public class UsuarioClaim
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
