using Microsoft.EntityFrameworkCore;

namespace Data.Presistance
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public DatabaseService(DbContextOptions<DatabaseService> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Data.Domain.Entities.Stock> Stocks { get; set; }
    }
}