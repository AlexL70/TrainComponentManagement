using Microsoft.EntityFrameworkCore;
using webapi.Infrastructure.Database.Models;

namespace webapi.Infrastructure.Database
{
    public class TrainComponentsDbContext : DbContext
    {
        public TrainComponentsDbContext(DbContextOptions<TrainComponentsDbContext> options) : base(options) { }

        #region DbSets
        public DbSet<TrainComponentType>  TrainComponentTypes { get; set; }
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
            SetupEntities(modelBuilder);
        }

        private void SetupEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainComponentType>()
                .HasIndex(_ => _.Name).IsUnique();
        }
    }
}
