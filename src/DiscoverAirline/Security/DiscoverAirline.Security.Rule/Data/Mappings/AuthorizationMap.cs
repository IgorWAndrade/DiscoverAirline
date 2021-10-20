using DiscoverAirline.Security.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscoverAirline.Security.Rule.Data.Mappings
{
    class AuthorizationMap : IEntityTypeConfiguration<Authorization>
    {
        public void Configure(EntityTypeBuilder<Authorization> builder)
        {
            builder.ToTable("Authorizations");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Role)
                .WithMany(x => x.Authorizations)
                .HasForeignKey(x => x.RoleId);

            builder.HasOne<Service>(x => x.Service)
                .WithMany(x => x.Authorizations)
                .HasForeignKey(x => x.ServiceId);

            builder.HasOne<Controller>(x => x.Controller)
                .WithMany(x => x.Authorizations)
                .HasForeignKey(x => x.ControllerId);

            builder.HasMany<Action>(x => x.Actions)
                .WithMany(x => x.Authorizations);
        }
    }
}
