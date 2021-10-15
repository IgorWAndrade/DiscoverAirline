using DiscoverAirline.Core;

namespace DiscoverAirline.Security.Domain.Entities
{
    public class ProfileRoles : BaseEntity
    {
        public int ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
