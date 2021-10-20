using DiscoverAirline.Core;
using System.Collections.Generic;

namespace DiscoverAirline.Security.Domain.Entities
{
    public class Authorization : BaseEntity
    {
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
        public int ControllerId { get; set; }
        public virtual Controller Controller { get; set; }
        public virtual List<Action> Actions { get; set; }
    }

}
