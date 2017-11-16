using System;
using System.Collections.Generic;
using System.Linq;
using Data.Domain.Entities;
using Data.Domain.Interfaces;
using Data.Persistence;

namespace Business
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseService _databaseService;

        public ProductRepository(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public IReadOnlyList<Product> Getall()
        {
            return _databaseService.Products.ToList();
        }

        public Product GetById(Guid id)
        {
            return _databaseService.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            _databaseService.Products.Add(product);
            _databaseService.SaveChanges();
        }

        public void Edit(Product product)
        {
            _databaseService.Products.Update(product);
            _databaseService.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var product = GetById(id);
            _databaseService.Products.Remove(product);
            _databaseService.SaveChanges();
        }
    }
}