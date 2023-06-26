using Microsoft.EntityFrameworkCore;
using webapi.Infrastructure.Database.Models;
using webapi.Infrastructure.Database.Seeding;

namespace webapi.Infrastructure.Database
{
    public class TrainComponentsDbContext : DbContext
    {
        public TrainComponentsDbContext(DbContextOptions<TrainComponentsDbContext> options) : base(options) { }

        #region DbSets
        public DbSet<TrainComponentType>?  TrainComponentTypes { get; set; }
        public DbSet<TrainComponentBrand>? TrainComponentBrands { get; set; }
        public DbSet<TrainModel>? TrainModels { get; set; }
        public DbSet<TrainModelElement>? TrainModelElements { get; set; }
        public DbSet<InventoryPart>? Inventory { get; set; }
        public DbSet<Train>? Trains { get; set; }
        public DbSet<TrainComponent>? TrainElements { get; set; }
        #endregion

#if DEBUG
        public static readonly LoggerFactory _myLoggerFactory =
            new LoggerFactory(new[] {
                new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
            });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.UseLoggerFactory(_myLoggerFactory);
        }
#endif
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseIdentityAlwaysColumns();
            SetupEntities(modelBuilder);
            Seed(modelBuilder);
        }

        private void SetupEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainComponentType>()
                .HasIndex(_ => _.Name).IsUnique();
            modelBuilder.Entity<TrainComponentType>()
                .Property(_ => _.Id).HasIdentityOptions(startValue: 501);
            modelBuilder.Entity<TrainComponentTypeRelation>()
                .HasKey(_ => new { _.ParentTypeId, _.ChildTypeId });
            modelBuilder.Entity<TrainComponentTypeRelation>()
                .HasOne(_ => _.ParentType)
                .WithMany(_ => _.CanHaveChildren)
                .HasForeignKey(_ => _.ParentTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TrainComponentTypeRelation>()
                .HasOne(_ => _.ChildType)
                .WithMany(_ => _.CanHaveParents)
                .HasForeignKey(_ => _.ChildTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TrainComponentBrand>()
                .HasIndex(_ => new { _.TypeId, _.Name }).IsUnique();
            modelBuilder.Entity<TrainComponentType>()
                .Property(_ => _.Id).HasIdentityOptions(startValue: 1001);
            modelBuilder.Entity<TrainComponentBrand>()
                .HasIndex(_ => _.TypeId);
            modelBuilder.Entity<InventoryPart>()
                .HasAlternateKey(_ => _.SerialNumber);
            modelBuilder.Entity<TrainModel>()
                .HasIndex(_ => _.Name).IsUnique();
            modelBuilder.Entity<TrainModelElement>()
                .HasIndex(_ => _.ModelId);
            modelBuilder.Entity<TrainModelElement>()
                .HasIndex(_ => _.ParentId);
            modelBuilder.Entity<TrainModelElement>()
                .HasIndex(_ => _.BrandId);
            //  Inventory Element (physical part) cannot be used in train(s) more than once
            //  i.e. there could not be more than one train component per inventory part
            modelBuilder.Entity<TrainComponent>()
                .HasIndex(_ => _.InventoryId).IsUnique();
        }

        private void Seed(ModelBuilder modelBuilder) {
            modelBuilder.Entity<TrainComponentType>()
                .HasData(SeedingData.componentTypes);
            modelBuilder.Entity<TrainComponentBrand>()
                .HasData(SeedingData.brands);
            modelBuilder.Entity<TrainComponentTypeRelation>()
                .HasData(SeedingData.relations);
        }
    }
}
