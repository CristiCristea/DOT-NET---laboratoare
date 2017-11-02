using System;

namespace Data
{
    public class Book
    {
        private Book()
        {
        }
        public Guid Id { get; private set; }

        public string Title { get; private set; }

        public int Year { get; private set; }

        public double Price { get; private set; }

        public string Genere { get; private set; }

        public static Book Create(string title, int year, double price, string genere)
        {
            var instance = new Book {Id = new Guid()};
            instance.Update(title, year, price, genere);
            return instance;
        }

        public void Update(string title, int year, double price, string genere)
        {
            Title = title;
            Year = year;
            Price = price;
            Genere = genere;
        }


    }
}
