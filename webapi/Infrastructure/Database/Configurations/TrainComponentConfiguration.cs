using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapi.Infrastructure.Database.Models;

namespace webapi.Infrastructure.Database.Configurations {
    public class TrainComponentConfiguration : IEntityTypeConfiguration<TrainComponent>
    {
        public void Configure(EntityTypeBuilder<TrainComponent> builder)
        {
            builder.HasOne(_ => _.ModelElement).WithMany(_ => _.TrainComponents).HasForeignKey(_ => _.ModelElementId);
            builder.HasOne(_ => _.Parent).WithMany(_ => _.Children).HasForeignKey(_ => _.ParentElementId);
            builder.HasOne(_ => _.Train).WithMany(_ => _.Components).HasForeignKey(_ => _.TrainId);
            //  Inventory Element (physical part) cannot be used in train(s) more than once
            //  i.e. there could not be more than one train component per inventory part
            builder.HasOne(_ => _.InventoryElement).WithOne(_ => _.TrainComponent).HasPrincipalKey<InventoryPart>();
            builder.Ignore(_ => _.SerialNumber);
        }
    }
}