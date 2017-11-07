using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EnsureThat;

namespace Data.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        [Required]
        [StringLength(50)]
        public string DistributorName { get; set; }

        public static Category Create(string title, string distributorName)
        {
            Ensure.That(title).IsNotNullOrEmpty();
            var instance = new Category { Id = Guid.NewGuid() };
            instance.Update(title, distributorName, null);
            return instance;
        }

        public void Update(string title, string distributorName, List<Product> products)
        {
            Ensure.That(title).IsNotNullOrEmpty();
            Title = title;
            DistributorName = distributorName;
            Products = Products.Concat(products).ToList();
        }
    }
}