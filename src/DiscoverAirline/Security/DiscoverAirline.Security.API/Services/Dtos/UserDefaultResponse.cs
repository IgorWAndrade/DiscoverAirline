using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscoverAirline.Security.API.Services.Dtos
{
    public class UserDefaultResponse
    {
        public UserToken UsuarioToken { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Type_Acess { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public DateTime ExpiresIn { get; set; }
    }

    public class UserToken
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<UserClaim> Claims { get; set; }
    }

    public class UserClaim
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }

    public class RefreshToken
    {
        public int Id { get; set; }
        public string UserId { get; set; } // Linked to the AspNet Identity User Id
        public string Token { get; set; }
        public string JwtId { get; set; } // Map the token with jwtId
        public bool IsUsed { get; set; } // if its used we dont want generate a new Jwt token with the same refresh token
        public bool IsRevoked { get; set; } // if it has been revoke for security reasons
        public DateTime AddedDate { get; set; }
        public DateTime ExpiryDate { get; set; } // Refresh token is long lived it could last for months.

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
    }
}
