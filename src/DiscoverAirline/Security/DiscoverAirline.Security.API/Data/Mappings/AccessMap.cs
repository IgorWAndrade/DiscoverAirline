using DiscoverAirline.Security.API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscoverAirline.Security.API.Data.Mappings
{
    public class AccessMap : IEntityTypeConfiguration<Access>
    {
        public void Configure(EntityTypeBuilder<Access> builder)
        {
            builder.ToTable("Accessess");

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(96);

            builder.HasOne<Domain.Application>(x => x.Application)
                .WithMany(x => x.Accessess)
                .HasForeignKey(x => x.ApplicationId);

        }
    }
}
