using System;
using Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistance
{
    public interface IDatabaseService : IDisposable
    {
        DbSet<Category> Categories { get; set; }

        DbSet<Product> Products { get; set; }

        int SaveChanges();
    }
}