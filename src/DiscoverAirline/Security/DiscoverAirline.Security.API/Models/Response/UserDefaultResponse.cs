using System.Collections.Generic;

namespace DiscoverAirline.Security.API.Models.Response
{
    public class UserDefaultResponse
    {
        public string AccessToken { get; set; }
        public string RefreshAccessToken { get; set; }
        public double ExpiresIn { get; set; }
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
}
