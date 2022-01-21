using DiscoverAirline.Core;
using System.Collections.Generic;

namespace DiscoverAirline.Security.API.Domain
{
    public class Policy : BaseEntity
    {
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

        public int ApplicationId { get; set; }

        public virtual Application Application { get; set; }

        public int AccessId { get; set; }

        public virtual Access Access { get; set; }

        public virtual List<Action> Actions { get; set; }
    }
}
