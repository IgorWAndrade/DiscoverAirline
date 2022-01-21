using DiscoverAirline.Security.API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DiscoverAirline.Security.API.Data.Mappings
{
    public class PolicyMap : IEntityTypeConfiguration<Policy>
    {
        public void Configure(EntityTypeBuilder<Policy> builder)
        {
            builder.ToTable("Policies");

            builder.HasOne<Role>(x => x.Role)
                .WithMany(x => x.Policies)
                .HasForeignKey(x => x.RoleId);

            builder.HasOne<Domain.Application>(x => x.Application)
                .WithMany(x => x.Policies)
                .HasForeignKey(x => x.ApplicationId);

            builder.HasOne<Access>(x => x.Access)
                .WithMany(x => x.Policies)
                .HasForeignKey(x => x.AccessId);

            builder.HasMany<Action>(x => x.Actions)
                .WithMany(x => x.Policies);

        }
    }
}
