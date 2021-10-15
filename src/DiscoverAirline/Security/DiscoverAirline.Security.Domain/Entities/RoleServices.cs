using DiscoverAirline.Core;

namespace DiscoverAirline.Security.Domain.Entities
{
    public class RoleServices : BaseEntity
    {
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
    }
}
