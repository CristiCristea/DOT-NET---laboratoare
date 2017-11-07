using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EnsureThat;

namespace Data.Domain.Entities
{
    public class Product
    {
        private Product()
        {

        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        public static Product Create(string description, double price)
        {
            Ensure.That(description).IsNotNullOrEmpty();
            var instance = new Product { Id = Guid.NewGuid() };
            instance.Update(description, price);
            return instance;
        }

        public void Update(string description, double price)
        {
            Ensure.That(description).IsNotNullOrEmpty();
            Description = description;
            Price = price;
        }
    }
}