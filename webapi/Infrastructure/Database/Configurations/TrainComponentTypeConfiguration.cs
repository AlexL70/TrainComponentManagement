using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapi.Infrastructure.Database.Models;

namespace webapi.Infrastructure.Database.Configurations {
    public class TrainComponentTypeConfiguration : IEntityTypeConfiguration<TrainComponentType>
    {
        public void Configure(EntityTypeBuilder<TrainComponentType> builder)
        {
                builder.HasIndex(_ => _.Name).IsUnique();
                builder.Property(_ => _.Id)
                    .HasIdentityOptions(startValue: 501);

        }
    }
}