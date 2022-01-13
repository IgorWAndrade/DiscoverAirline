using DiscoverAirline.Security.API.Rules.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiscoverAirline.Security.API.Repositories
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
