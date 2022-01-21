using DiscoverAirline.Security.API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscoverAirline.Security.API.Data.Mappings
{
    class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(96);

            builder.Property(x => x.Description)
                .HasColumnName("Description")
                .HasMaxLength(512);

            builder.HasMany<User>(x => x.Users)
                .WithMany(x => x.Roles);

            builder.HasMany<Policy>(x => x.Policies)
                .WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleId);

        }
    }
}
