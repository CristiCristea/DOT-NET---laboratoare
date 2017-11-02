using Data;
using Microsoft.EntityFrameworkCore;

namespace Context
{
    public interface IDatabaseService
    {
        DbSet<Book> Books { get; set; }
        int SaveChanges();
    }
}