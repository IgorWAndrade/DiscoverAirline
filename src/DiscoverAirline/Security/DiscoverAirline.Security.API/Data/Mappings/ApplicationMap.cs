using DiscoverAirline.Security.API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscoverAirline.Security.API.Data.Mappings
{
    public class ApplicationMap : IEntityTypeConfiguration<Domain.Application>
    {
        public void Configure(EntityTypeBuilder<Domain.Application> builder)
        {
            builder.ToTable("Applications");

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(96);

            builder.HasMany<Access>(x => x.Accessess)
                .WithOne(X => X.Application)
                .HasForeignKey(x => x.ApplicationId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
