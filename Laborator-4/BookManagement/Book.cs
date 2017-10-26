using System;

namespace BookManagement
{
    public class Book
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public int Year { get; private set; }
        public double Price { get; private set; }
        public string Genere { get; private set; }

        public Book(string title, int year, double price, string genere)
        {
            if (price < 0)
            {
                throw new ArgumentException("Price should be greatear than 0!");
            }
            if (year > 2017)
            {
                throw new ArgumentException("Price should be lower than 0!");

            }

            Id = Guid.NewGuid();
            Title = title;
            Year = year;
            Genere = genere;
        }
    }

}
