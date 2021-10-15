using System.Collections.Generic;

namespace DiscoverAirline.CoreAPI.Models
{
    public class UserProfile
    {
        public UserProfile(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public List<ServiceProfile> Services { get; set; } = new List<ServiceProfile>();


    }
    public class ServiceProfile
    {
        public ServiceProfile(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public List<ControllerProfile> Controllers { get; set; } = new List<ControllerProfile>();
    }

    public class ControllerProfile
    {
        public ControllerProfile(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public List<string> Actions { get; set; } = new List<string>();
    }
}
