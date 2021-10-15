using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscoverAirline.Security.Rule.Data.Mappings
{
    class ActionMap : IEntityTypeConfiguration<DiscoverAirline.Security.Domain.Entities.Action>
    {
        public void Configure(EntityTypeBuilder<DiscoverAirline.Security.Domain.Entities.Action> builder)
        {
            builder.ToTable("Actions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(64)
                .IsRequired();
        }
    }
}
