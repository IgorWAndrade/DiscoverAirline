using DiscoverAirline.Security.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscoverAirline.Security.Rule.Data.Mappings
{
    class RoleServicesMap : IEntityTypeConfiguration<RoleServices>
    {
        public void Configure(EntityTypeBuilder<RoleServices> builder)
        {
            builder.ToTable("RoleServices");

            builder.HasKey(x => new { x.RoleId, x.ServiceId });

            builder.HasOne<Service>(x => x.Service)
                .WithMany(s => s.Roles)
                .HasForeignKey(sc => sc.ServiceId);

            builder.HasOne<Role>(x => x.Role)
                .WithMany(s => s.Services)
                .HasForeignKey(sc => sc.RoleId);

            builder.Ignore(x => x.Id);
        }
    }
}
