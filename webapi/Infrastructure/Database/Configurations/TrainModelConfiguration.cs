using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapi.Infrastructure.Database.Models;

namespace webapi.Infrastructure.Database.Configurations {
    public class TrainModelConfiguration : IEntityTypeConfiguration<TrainModel>
    {
        public void Configure(EntityTypeBuilder<TrainModel> builder)
        {
            builder
                .HasOne(_ => _.ParentElement).WithMany(_ => _.ModelsWhereParentIs)
                .HasForeignKey(_ => _.ParentElementId);
            builder.HasIndex(_ => _.Name).IsUnique();
            //  Each model can have only one parent element
            builder.HasIndex(_ => _.ParentElementId).IsUnique();
        }
    }
}