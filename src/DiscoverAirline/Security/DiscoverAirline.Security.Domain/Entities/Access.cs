using DiscoverAirline.Core;
using System.Collections.Generic;

namespace DiscoverAirline.Security.Domain.Entities
{
    public class Access : BaseEntity
    {
        public string Name { get; set; }
        public virtual List<Authorization> Authorizations { get; set; } = new List<Authorization>();
    }
}
