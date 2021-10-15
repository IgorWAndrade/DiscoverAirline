using DiscoverAirline.Security.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscoverAirline.Security.Rule.Data.Mappings
{
    class UserRefreshTokenMap : IEntityTypeConfiguration<UserRefreshToken>
    {
        public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            builder.ToTable("Tokens");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ExpiryDate)
                .HasColumnName("ExpirationDate")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(x => x.UserId)
                .HasColumnName("UserId")
                .IsRequired();

            builder.Property(x => x.Token)
                .HasColumnName("Code")
                .HasMaxLength(144)
                .IsRequired();

            builder.HasOne<User>(x => x.User)
                .WithOne(x => x.Token)
                .HasForeignKey<UserRefreshToken>(x => x.UserId);
        }
    }
}
