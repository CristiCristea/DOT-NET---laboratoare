using System;
using System.Collections.Generic;
using System.Linq;
using Context;
using Data;

namespace Business
{
    public class BookRepository : Repository<Book>
    {
        public BookRepository(IDatabaseService databaseService) : base(databaseService)
        {
        }

        public override Book GetById(Guid id)
        {
            return DatabaseService.Books.FirstOrDefault(b => b.Id == id);
        }

        public override IReadOnlyList<Book> GetAll()
        {
            return DatabaseService.Books.ToList();
        }

        public override void Add(Book entity)
        {
            DatabaseService.Books.Add(entity);
            DatabaseService.SaveChanges();
        }

        public override void Edit(Book entity)
        {
            DatabaseService.Books.Update(entity);
            DatabaseService.SaveChanges();
        }

        public override void Delete(Guid id)
        {
            var book = GetById(id);
            DatabaseService.Books.Remove(book);
            DatabaseService.SaveChanges();
        }
    }
}