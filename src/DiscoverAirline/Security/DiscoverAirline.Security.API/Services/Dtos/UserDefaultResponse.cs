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
        public string UserId { get; set; } 
        public string Token { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ExpiryDate { get; set; } 
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
    }
}
