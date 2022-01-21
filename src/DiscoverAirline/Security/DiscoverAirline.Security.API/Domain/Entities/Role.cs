using DiscoverAirline.Core;
using System.Collections.Generic;

namespace DiscoverAirline.Security.API.Domain
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<User> Users { get; set; }
        public virtual List<Policy> Policies { get; set; }
    }
}
