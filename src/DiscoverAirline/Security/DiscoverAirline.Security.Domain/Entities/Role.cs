using DiscoverAirline.Core;
using System.Collections.Generic;

namespace DiscoverAirline.Security.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public virtual List<ProfileRoles> Profiles { get; set; }
        public virtual List<RoleServices> Services { get; set; }

        public static Role ToCreatedFromClass(dynamic model)
        {
            return new Role
            {
                Name = model.Name
            };
        }
    }
}
