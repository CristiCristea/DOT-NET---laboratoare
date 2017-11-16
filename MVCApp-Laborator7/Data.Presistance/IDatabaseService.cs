using Microsoft.EntityFrameworkCore;

namespace Data.Presistance
{
    public interface IDatabaseService
    {
        DbSet<Data.Domain.Entities.Stock> Stocks { get; set; }
        int SaveChanges();
    }
}