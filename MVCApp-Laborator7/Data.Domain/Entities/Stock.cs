using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class Stock
    {
        public Stock()
        {
        }

        public Guid Id { get; private set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Code { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int EndPrice { get; set; }

        [Required]
        public int StartPrice { get; set; }

        public static Stock Create(string name, int code, DateTime date, int startPrice, int endPrice)
        {
            var instance = new Stock {Id = Guid.NewGuid()};
            instance.Update(name, code, date, startPrice, endPrice);
            return instance;
        }

        public void Update(string name, int code, DateTime date, int startPrice, int endPrice)
        {
            if (code < 0)
            {
                throw new ArgumentException("Code should be great than 0");
            }
            if (startPrice < 0)
            {
                throw new ArgumentException("Start Price should be great than 0");
            }
            if (endPrice < 0)
            {
                throw new ArgumentException("End Price should be great than 0");
            }
            Name = name;
            Code = code;
            Date = date;
            StartPrice = startPrice;
            EndPrice = endPrice;
        }
    }
}