using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapi.Infrastructure.Database.Models;

namespace webapi.Infrastructure.Database.Configurations {
    public class TrainComponentBrandConfiguration : IEntityTypeConfiguration<TrainComponentBrand>
    {
        public void Configure(EntityTypeBuilder<TrainComponentBrand> builder)
        {
            builder.HasIndex(_ => new { _.TypeId, _.Name }).IsUnique();
            builder.Property(_ => _.Id).HasIdentityOptions(startValue: 1001);
            builder.HasIndex(_ => _.TypeId);
            builder.HasOne(_ => _.Type).WithMany(_ => _.BrandsAvailable).HasForeignKey(_ => _.TypeId);
            builder.Ignore(_ => _.IsRoot);
            builder.Ignore(_ => _.CanAssignQuantity);
            builder.Ignore(_ => _.TypeName);
        }
    }
}