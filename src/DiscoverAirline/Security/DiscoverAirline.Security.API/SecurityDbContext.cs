﻿using DiscoverAirline.Security.API.Services.Dtos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiscoverAirline.Security.API
{
    public class SecurityDbContext : IdentityDbContext
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options) { }

        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
