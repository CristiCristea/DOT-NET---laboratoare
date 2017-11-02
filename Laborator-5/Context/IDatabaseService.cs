using Model;
using Microsoft.EntityFrameworkCore;

namespace Context
{
    public interface IDatabaseService
    {
        DbSet<Car> Cars { get; set; }
        int SaveChanges();
    }
}