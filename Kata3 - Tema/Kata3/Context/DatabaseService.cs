using Data;
using Microsoft.EntityFrameworkCore;

namespace Context
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public DatabaseService(DbContextOptions<DatabaseService> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}