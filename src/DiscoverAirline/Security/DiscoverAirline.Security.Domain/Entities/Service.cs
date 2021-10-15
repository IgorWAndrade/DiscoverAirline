using DiscoverAirline.Core;
using System.Collections.Generic;

namespace DiscoverAirline.Security.Domain.Entities
{
    public class Service : BaseEntity
    {
        public string Name { get; set; }
        public virtual List<RoleServices> Roles { get; set; }
        public virtual List<ServiceControllers> Controllers { get; set; }
    }
}
