using Microsoft.EntityFrameworkCore;

namespace webapi.Infrastructure.Database
{
    public class TrainComponentsDbContext : DbContext
    {
        public TrainComponentsDbContext(DbContextOptions<TrainComponentsDbContext> options) : base(options) { }
    }
}
