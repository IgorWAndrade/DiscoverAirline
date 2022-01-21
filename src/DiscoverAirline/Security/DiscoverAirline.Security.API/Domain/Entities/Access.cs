using DiscoverAirline.Core;

namespace DiscoverAirline.Security.API.Domain
{
    public class Access : BaseEntity
    {
        public string Name { get; set; }

        public int ApplicationId { get; set; }

        public virtual Application Application { get; set; }
    }
}
