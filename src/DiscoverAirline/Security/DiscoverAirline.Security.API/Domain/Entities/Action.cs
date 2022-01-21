using DiscoverAirline.Core;
using System.Collections.Generic;

namespace DiscoverAirline.Security.API.Domain
{
    public class Action : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<Policy> Policies { get; set; }
    }
}
