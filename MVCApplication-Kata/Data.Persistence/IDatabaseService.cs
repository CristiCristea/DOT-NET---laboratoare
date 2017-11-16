using Microsoft.EntityFrameworkCore;
namespace Data.Persistence
{
    public interface IDatabaseService
    {
        DbSet<Data.Domain.Entities.Product> Products { get; set; }
        int SaveChanges();
    }
}