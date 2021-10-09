using System.Collections.Generic;

namespace DiscoverAirline.CoreAPI.Models
{
    public class UserProfile
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public List<UserProfileRoleClaims> Permissions { get; set; } = new List<UserProfileRoleClaims>();
    }

    public class UserProfileRoleClaims
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public UserProfileClaim Permissions { get; set; }
    }

    public class UserProfileClaim
    {
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
