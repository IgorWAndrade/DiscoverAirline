using DiscoverAirline.Core;
using System.Collections.Generic;

namespace DiscoverAirline.Security.Domain.Entities
{
    public class Profile : BaseEntity
    {
        public virtual User User { get; set; }

        public int UserId { get; set; }

        public virtual List<ProfileRoles> Roles { get; set; }
    }
}
