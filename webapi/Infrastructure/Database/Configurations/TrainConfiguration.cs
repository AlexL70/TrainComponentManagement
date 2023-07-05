using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapi.Infrastructure.Database.Models;

namespace webapi.Infrastructure.Database.Configurations {
    public class TrainConfiguration : IEntityTypeConfiguration<Train>
    {
        public void Configure(EntityTypeBuilder<Train> builder)
        {
            builder
                .HasOne(_ => _.RootComponent).WithMany(_ => _.TrainsWhereRootComponentIs)
                .HasForeignKey(_ => _.RootComponentId);
            //  Each train can have only one root component
            builder.HasIndex(_ => _.RootComponentId).IsUnique();
            builder.HasOne(_ => _.Model).WithMany(_ => _.Trains).HasForeignKey(_ => _.ModelId);
            builder.Ignore(_ => _.SerialNumber);
        }
    }
}