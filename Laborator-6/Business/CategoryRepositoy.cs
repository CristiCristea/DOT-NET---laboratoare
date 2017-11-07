using System;
using System.Collections.Generic;
using System.Linq;
using Data.Domain.Entities;
using Data.Domain.Interfaces;
using Data.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class CategoryRepositoy : ICategoryRepository
    {
        private readonly IDatabaseService _databaseService;

        public CategoryRepositoy(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public IReadOnlyList<Category> GetAll()
        {
            return _databaseService.Categories.ToList();
        }

        public Category GetById(Guid id)
        {
            return _databaseService.Categories.FirstOrDefault(t => t.Id == id);
        }

        public void Add(Category todo)
        {
            _databaseService.Categories.Add(todo);
            _databaseService.SaveChanges();
        }

        public void Edit(Category todo)
        {
            _databaseService.Categories.Update(todo);
            _databaseService.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var todo = GetById(id);
            _databaseService.Categories.Remove(todo);
            _databaseService.SaveChanges();
        }

        public List<Category> GetAllCategories_eager()
        {
            var context = _databaseService;
            var categories = context.Categories
                .Include(category => category.Id)
                .Include(category => category.Title)
                .Include(category => category.DistributorName)
                .Include(category => category.Products)
                .ThenInclude(products => products)
                .ToList();
            return categories;
        }

        public List<Category> NumberOfProductsFromCategories_eager()
        {
            var context = _databaseService;
            var categories = context.Categories
                .Include(category => category.Id)
                .Include(category => category.Title)
                .Include(category => category.DistributorName)
                .Include(category => category.Products.Count)
                .ToList();
            return categories;
        }
    }
}