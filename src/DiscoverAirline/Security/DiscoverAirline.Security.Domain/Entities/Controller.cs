using DiscoverAirline.Core;
using System.Collections.Generic;

namespace DiscoverAirline.Security.Domain.Entities
{
    public class Controller : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<ServiceControllers> Services { get; set; }

        public virtual List<ControllerActions> Actions { get; set; }
    }
}
