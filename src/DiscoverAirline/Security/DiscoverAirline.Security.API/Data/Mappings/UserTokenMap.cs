using DiscoverAirline.Security.API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscoverAirline.Security.API.Data.Mappings
{
    public class UserTokenMap : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.ToTable("UserTokens");

            builder.Property(x => x.Token)
                .HasColumnName("Token")
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(x => x.ExpiryDate)
                 .HasColumnName("ExpiryDate")
                 .HasColumnType("datetime")
                 .IsRequired();

            builder.HasOne<User>(x => x.User)
                .WithMany(x => x.Tokens)
                .HasForeignKey(x => x.UserId);
        }
    }
}
