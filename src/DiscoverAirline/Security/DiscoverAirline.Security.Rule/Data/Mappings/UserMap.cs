using DiscoverAirline.Security.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscoverAirline.Security.Rule.Data.Mappings
{
    class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(96);

            builder.Property(x => x.Cpf)
                .HasColumnName("Cpf")
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(x => x.PasswordHash)
                .HasColumnName("Password")
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(x => x.RoleId)
                .HasColumnName("RoleId")
                .IsRequired(false);

            builder.Ignore(x => x.Address);

            builder.Ignore(x => x.Password);

            builder.HasOne<Role>(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId);
        }
    }
}
