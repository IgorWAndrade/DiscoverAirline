using System;
using System.Collections.Generic;

namespace DiscoverAirline.Security.API.Models.Response
{
    public class UserDefaultResponse
    {
        public string AccessToken { get; set; }
        public RefreshToken RefreshAccessToken { get; set; }
        public string Type_Acess { get; set; }
        public DateTime ExpiresIn { get; set; }
        public UserToken UsuarioToken { get; set; }
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
        public string Username { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
