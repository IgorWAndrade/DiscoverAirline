using DiscoverAirline.Core;
using System.Collections.Generic;

namespace DiscoverAirline.Security.API.Domain
{
    public class Application : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<Access> Accessess { get; set; }
    }
}
