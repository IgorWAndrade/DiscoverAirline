using DiscoverAirline.Core;
using System.Collections.Generic;

namespace DiscoverAirline.Security.Domain.Entities
{
    public class Action : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<ControllerActions> Controllers { get; set; }
    }
}
