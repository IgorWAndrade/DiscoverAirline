using DiscoverAirline.Security.API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscoverAirline.Security.API.Data.Mappings
{
    class ActionMap : IEntityTypeConfiguration<Action>
    {
        public void Configure(EntityTypeBuilder<Action> builder)
        {
            builder.ToTable("Actions");

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(96);

            builder.HasMany<Policy>(x => x.Policies)
                .WithMany(x => x.Actions);
        }
    }
}
