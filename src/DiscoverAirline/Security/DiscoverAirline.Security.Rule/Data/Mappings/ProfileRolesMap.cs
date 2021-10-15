using DiscoverAirline.Security.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscoverAirline.Security.Rule.Data.Mappings
{
    class ProfileRolesMap : IEntityTypeConfiguration<ProfileRoles>
    {
        public void Configure(EntityTypeBuilder<ProfileRoles> builder)
        {
            builder.ToTable("ProfileRoles");

            builder.HasKey(x => new { x.ProfileId, x.RoleId });

            builder.HasOne<Profile>(x => x.Profile)
                .WithMany(s => s.Roles)
                .HasForeignKey(sc => sc.ProfileId);

            builder.HasOne<Role>(x => x.Role)
                .WithMany(s => s.Profiles)
                .HasForeignKey(sc => sc.RoleId);

            builder.Ignore(x => x.Id);
        }
    }
}
