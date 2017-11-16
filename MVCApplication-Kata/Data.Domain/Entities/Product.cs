using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class Product
    {
        public Product (){
        }

        public Guid Id { get; private set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }

        public static Product Create(string description, int price)
        {
            var instace = new Product() {Id = new Guid()};
            instace.Update(description,price);
            return instace;
        }

        public void Update(string descirption, int price)
        {
            if (descirption == null)
            {
                throw new ArgumentNullException("Description should not be null");
            }
            if (price < 0)
            {
                throw new ArgumentException("Price should be greater than 0");
            }

            Description = descirption;
            Price = price;
        }
    }
}
