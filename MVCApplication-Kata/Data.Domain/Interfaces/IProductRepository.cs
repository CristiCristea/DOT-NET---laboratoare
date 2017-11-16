using System;
using System.Collections.Generic;
using Data.Domain.Entities;

namespace Data.Domain.Interfaces
{
    public interface IProductRepository
    {
        IReadOnlyList<Product> Getall();
        Product GetById(Guid id);
        void Add(Product product);
        void Edit(Product product);
        void Delete(Guid id);
    }
}