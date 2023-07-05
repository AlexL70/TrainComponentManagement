using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapi.Infrastructure.Database.Models;

namespace  webapi.Infrastructure.Database.Configurations {
    public class InventoryPartConfiguration : IEntityTypeConfiguration<InventoryPart>
    {
        public void Configure(EntityTypeBuilder<InventoryPart> builder)
        {
            builder.HasAlternateKey(_ => _.SerialNumber);
            builder.HasOne(_ => _.Brand).WithMany(_ => _.Inventory).HasForeignKey(_ => _.BrandId);
        }
    }
}