using DiscoverAirline.Core;
using System.Collections.Generic;

namespace DiscoverAirline.Security.API.Domain
{
    public class Access : BaseEntity
    {
        public string Name { get; set; }

        public int ApplicationId { get; set; }

        public virtual Application Application { get; set; }

        public virtual List<Policy> Policies { get; set; }
    }
}
