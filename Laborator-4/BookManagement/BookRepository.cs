using System.Collections.Generic;
using System.Linq;

namespace BookManagement
{
    public  class BookRepository
    {
        private List<Book> Books;

        public BookRepository(List<Book> books)
        {
            Books = books;
        }

        public List<Book> RetriveAllBooks_Querry()
        {
            var bookToRetrun =
                from book in Books
                select book;
            return bookToRetrun.ToList();
        }

        public List<Book> RetriveAllOrderByYearDescending_Querry()
        {
            var bookToRetrun =
                from book in Books
                orderby book.Year descending 
                select book;
            return bookToRetrun.ToList();
        }

        public List<Book> RetriveAllOrderByYearAscending_Querry()
        {
            var bookToRetrun =
                from book in Books
                orderby book.Year
                select book;
            return bookToRetrun.ToList();
        }

        public List<Book> RetriveAllOrderByPriceAscending_Querry()
        {
            var bookToRetrun =
                from book in Books
                orderby book.Price
                select book;
            return bookToRetrun.ToList();
        }

        public List<Book> RetriveAllOrderByPriceDescending_Querry()
        {
            var bookToRetrun =
                from book in Books
                orderby book.Price descending 
                select book;
            return bookToRetrun.ToList();
        }

         public Dictionary<string, List<Book>> RetriveAllBooksGroupedByGenre_Querry()
         {
             var bookToRetrun =
                 from book in Books
                 group book by book.Genere
                 into dict
                 select new {MyKey = dict.Key, Values = dict.ToList()};
             return bookToRetrun.ToDictionary(myKey => myKey.MyKey, arg => arg.Values);
         }

        public List<Book> RetriveAllBooks_MethodSyntax()
        {
            var bookToRetrun = Books.Select(book => book);
            return bookToRetrun.ToList();
        }

        public List<Book> RetriveAllOrderByYearDescending_MethodSyntax()
        {
            var bookToRetrun = Books.OrderByDescending(book => book.Year);
            return bookToRetrun.ToList();
        }

        public List<Book> RetriveAllOrderByYearAscending_MethodSyntax()
        {
            var bookToRetrun = Books.OrderBy(book => book.Year);
            return bookToRetrun.ToList();
        }

        public List<Book> RetriveAllOrderByPriceAscending_MethodSyntax()
        {
            var bookToRetrun = Books.OrderBy(book => book.Price);
            return bookToRetrun.ToList();
        }

        public List<Book> RetriveAllOrderByPriceDescending_MethodSyntax()
        {
            var bookToRetrun = Books.OrderByDescending(book => book.Price);
            return bookToRetrun.ToList();
        }

       public Dictionary<string, List<Book>> RetriveAllOrderByStartDateAndInactiveDescending_MethodSyntax()
        {
            var bookToRetrun = Books.GroupBy(book => book.Genere)
                .Select(dict => new {MyKey = dict.Key, Values = dict.ToList()});
            return bookToRetrun.ToDictionary(myKey => myKey.MyKey, arg => arg.Values);
        } 
    }
}
