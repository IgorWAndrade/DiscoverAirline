using DiscoverAirline.Security.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscoverAirline.Security.Rule.Data.Mappings
{
    class ProfileMap : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("Profiles");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId)
                .HasColumnName("UserId")
                .IsRequired();

            builder.HasOne<User>(x => x.User)
                .WithOne(x => x.Profile)
                .HasForeignKey<Profile>(x => x.UserId);
        }
    }
}
