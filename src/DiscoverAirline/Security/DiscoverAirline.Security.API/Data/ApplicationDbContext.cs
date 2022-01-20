using DiscoverAirline.Security.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace DiscoverAirline.Security.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserToken> UserTokens { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Policy> Policies { get; set; }
        public virtual DbSet<DiscoverAirline.Security.API.Domain.Application> Applications { get; set; }
        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<Access> Accesses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
