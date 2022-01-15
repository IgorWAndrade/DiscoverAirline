using DiscoverAirline.Security.API.Application.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiscoverAirline.Security.API.Repositories
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<UserRefreshToken> AspNetUsersRefreshTokens { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
