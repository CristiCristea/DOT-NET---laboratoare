using Microsoft.EntityFrameworkCore;

namespace Data.Persistence
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public DatabaseService(DbContextOptions<DatabaseService> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Data.Domain.Entities.Product> Products { get; set; }
    }
}