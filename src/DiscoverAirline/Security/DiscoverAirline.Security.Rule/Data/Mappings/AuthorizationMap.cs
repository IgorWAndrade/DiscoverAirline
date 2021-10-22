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

            builder.HasOne<Application>(x => x.Application)
                .WithMany(x => x.Authorizations)
                .HasForeignKey(x => x.ApplicationId);

            builder.HasOne<Access>(x => x.Access)
                .WithMany(x => x.Authorizations)
                .HasForeignKey(x => x.AccessId);

            builder.HasMany<Action>(x => x.Actions)
                .WithMany(x => x.Authorizations);
        }
    }
}
