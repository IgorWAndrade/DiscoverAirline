using DiscoverAirline.Core;
using System.Collections.Generic;

namespace DiscoverAirline.Security.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string BusinessName { get; set; }
        public virtual List<User> Users { get; set; }
        public virtual List<Authorization> Authorizations { get; set; }
    }
}
