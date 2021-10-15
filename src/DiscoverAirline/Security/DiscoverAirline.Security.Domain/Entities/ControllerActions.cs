using DiscoverAirline.Core;

namespace DiscoverAirline.Security.Domain.Entities
{
    public class ControllerActions : BaseEntity
    {
        public int ControllerId { get; set; }
        public virtual Controller Controller { get; set; }
        public int ActionId { get; set; }
        public virtual Action Action { get; set; }
    }
}
