using DiscoverAirline.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscoverAirline.Security.Rule.Data.Mappings
{
    public class BaseEntityMap<T> : IEntityTypeConfiguration<T>
            where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.CreatedDate)
                 .HasColumnName("CreatedDate")
                 .HasColumnType("datetime")
                 .IsRequired();
        }
    }
}
