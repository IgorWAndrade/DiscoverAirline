using DiscoverAirline.Security.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscoverAirline.Security.Rule.Data.Mappings
{
    class ControllerActionsMap : IEntityTypeConfiguration<ControllerActions>
    {
        public void Configure(EntityTypeBuilder<ControllerActions> builder)
        {
            builder.ToTable("ControllerActions");

            builder.HasKey(x => new { x.ActionId, x.ControllerId });

            builder.HasOne<Controller>(x => x.Controller)
                .WithMany(s => s.Actions)
                .HasForeignKey(sc => sc.ControllerId);

            builder.HasOne<Domain.Entities.Action>(x => x.Action)
                .WithMany(s => s.Controllers)
                .HasForeignKey(sc => sc.ActionId);

            builder.Ignore(x => x.Id);
        }
    }
}
