using Microsoft.EntityFrameworkCore;
using webapi.Infrastructure.Database.Configurations;
using webapi.Infrastructure.Database.Models;
using webapi.Infrastructure.Database.Seeding;

namespace webapi.Infrastructure.Database
{
    public class TrainComponentsDbContext : DbContext
    {
        public TrainComponentsDbContext(DbContextOptions<TrainComponentsDbContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

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
            new TrainComponentTypeConfiguration()
                .Configure(modelBuilder.Entity<TrainComponentType>());
            new TrainComponentTypeRelationConfiguration()
                .Configure(modelBuilder.Entity<TrainComponentTypeRelation>());
            new TrainComponentBrandConfiguration()
                .Configure(modelBuilder.Entity<TrainComponentBrand>());
            new InventoryPartConfiguration()
                .Configure(modelBuilder.Entity<InventoryPart>());
            new TrainModelConfiguration()
                .Configure(modelBuilder.Entity<TrainModel>());
            new TrainModelElementConfiguration()
                .Configure(modelBuilder.Entity<TrainModelElement>());
            new TrainConfiguration()
                .Configure(modelBuilder.Entity<Train>());
            new TrainComponentConfiguration()
                .Configure(modelBuilder.Entity<TrainComponent>());
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
