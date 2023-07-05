
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapi.Infrastructure.Database.Models;

namespace webapi.Infrastructure.Database.Configurations
{
    public class TrainComponentTypeRelationConfiguration : IEntityTypeConfiguration<TrainComponentTypeRelation>
    {
        public void Configure(EntityTypeBuilder<TrainComponentTypeRelation> builder)
        {
            builder.HasKey(_ => new { _.ParentTypeId, _.ChildTypeId });
            builder
                .HasOne(_ => _.ParentType)
                .WithMany(_ => _.CanHaveChildren)
                .HasForeignKey(_ => _.ParentTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(_ => _.ChildType)
                .WithMany(_ => _.CanHaveParents)
                .HasForeignKey(_ => _.ChildTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
