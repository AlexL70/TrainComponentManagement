using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapi.Infrastructure.Database.Models;

namespace webapi.Infrastructure.Database.Configurations {
    public class TrainModelElementConfiguration : IEntityTypeConfiguration<TrainModelElement>
    {
        public void Configure(EntityTypeBuilder<TrainModelElement> builder)
        {
            builder.HasOne(_ => _.Model).WithMany(_ => _.Elements).HasForeignKey(_ => _.ModelId);
            builder.HasOne(_ => _.Brand).WithMany(_ => _.ModelElements).HasForeignKey(_ => _.BrandId);
            builder.HasOne(_ => _.Parent).WithMany(_ => _.Children).HasForeignKey(_ => _.ParentId);
            builder.HasIndex(_ => _.ModelId);
            builder.HasIndex(_ => _.ParentId);
            builder.HasIndex(_ => _.BrandId);
            builder.Ignore(_ => _.IsRoot);
            builder.Ignore(_ => _.CanAssignQuantity);
        }
    }
}