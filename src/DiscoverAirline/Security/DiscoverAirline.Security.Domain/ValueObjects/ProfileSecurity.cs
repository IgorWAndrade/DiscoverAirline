using System.Collections.Generic;

namespace DiscoverAirline.Security.Domain.ValueObjects
{
    public class ProfileSecurity
    {
        public ProfileSecurity(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public List<ServiceSecurity> Services { get; set; } = new List<ServiceSecurity>();


    }
    public class ServiceSecurity
    {
        public ServiceSecurity(int id,string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<ControllerSecurity> Controllers { get; set; } = new List<ControllerSecurity>();
    }

    public class ControllerSecurity
    {
        public ControllerSecurity(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Actions { get; set; } = new List<string>();
    }
}
