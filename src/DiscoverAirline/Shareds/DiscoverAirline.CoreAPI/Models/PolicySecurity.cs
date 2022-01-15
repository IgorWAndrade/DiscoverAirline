using System.Collections.Generic;

namespace DiscoverAirline.CoreAPI.Models
{
    public class PolicySecurity
    {
        public string Service { get; set; }
        public IList<ClaimSecurity> Claims { get; set; }
    }

    public class ClaimSecurity
    {
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
