using DiscoverAirline.Core;

namespace DiscoverAirline.Security.Domain.Entities
{
    public class ServiceControllers : BaseEntity
    {
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
        public int ControllerId { get; set; }
        public virtual Controller Controller { get; set; }
    }
}
