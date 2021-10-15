using DiscoverAirline.Security.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscoverAirline.Security.Rule.Data.Mappings
{
    class ServiceControllersMap : IEntityTypeConfiguration<ServiceControllers>
    {
        public void Configure(EntityTypeBuilder<ServiceControllers> builder)
        {
            builder.ToTable("ServiceControllers");

            builder.HasKey(x => new { x.ControllerId, x.ServiceId });

            builder.HasOne<Service>(x => x.Service)
                .WithMany(s => s.Controllers)
                .HasForeignKey(sc => sc.ServiceId);

            builder.HasOne<Controller>(x => x.Controller)
                .WithMany(s => s.Services)
                .HasForeignKey(sc => sc.ControllerId);

            builder.Ignore(x => x.Id);
        }
    }
}