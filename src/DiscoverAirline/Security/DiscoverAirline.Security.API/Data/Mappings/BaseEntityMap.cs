using DiscoverAirline.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscoverAirline.Security.API.Data.Mappings
{
    class BaseEntityMap<T> : IEntityTypeConfiguration<T>
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


            builder.Property(x => x.Active)
                 .HasColumnName("Active")
                 .HasDefaultValue(true)
                 .IsRequired();

            builder.Property(x => x.CreatedDate)
                 .HasColumnName("CreatedDate")
                 .HasColumnType("datetime")
                 .IsRequired();

            builder.Property(x => x.UpdateDate)
                 .HasColumnName("UpdateDate")
                 .HasColumnType("datetime")
                 .IsRequired();
        }
    }
}
