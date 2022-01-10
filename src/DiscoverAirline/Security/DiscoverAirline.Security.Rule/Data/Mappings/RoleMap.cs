using DiscoverAirline.Security.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscoverAirline.Security.Rule.Data.Mappings
{
    class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(x => x.BusinessName)
                .HasColumnName("BusinessName")
                .HasDefaultValue("")
                .IsRequired(false)
                .HasMaxLength(64);

            builder.HasMany<Authorization>(x => x.Authorizations)
                .WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleId);

        }
    }
}
