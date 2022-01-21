using DiscoverAirline.Security.API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscoverAirline.Security.API.Data.Mappings
{
    class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(96);

            builder.Property(x => x.PasswordHash)
                .HasColumnName("Password")
                .IsRequired()
                .HasMaxLength(64);

            builder.HasMany<UserToken>(x => x.Tokens)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder.HasMany<Role>(x => x.Roles)
                .WithMany(x => x.Users);

            builder.Ignore(x => x.Password);
        }
    }
}
