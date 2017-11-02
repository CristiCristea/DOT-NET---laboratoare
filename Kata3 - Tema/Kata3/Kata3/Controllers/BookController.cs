using System;
using System.Collections.Generic;
using System.Net;
using Business;
using Data;
using Kata3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kata3.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly Repository<Book> Repository;

        public BookController(Repository<Book> repository)
        {
            Repository = repository;
        }

        [HttpPost]
        public void CreateBook([FromBody]CreateBookModel book)
        {
            var entity = Book.Create(book.Title, book.Year, book.Price, book.Genere);
            Repository.Add(entity);
            Response.StatusCode = 200;//ok
        }

        [HttpPut("{id}")]
        public void EditBook(Guid id, [FromBody] UpdateBookModel book)
        {
            var entity = Repository.GetById(id);
            if (entity != null)
            {
                entity.Update(book.Title, book.Year, book.Price, book.Genere);
                Repository.Edit(entity);
            }
            else
            {
                Response.StatusCode = 404;
            }
        }

        [HttpDelete("{id}")]
        public void DeleteBook(Guid id)
        {
            var entity = Repository.GetById(id);
            if (entity != null)
            {

                Repository.Delete(id);
            }
            else
            {
                Response.StatusCode = 400;
            }
        }

        [HttpGet("(id)")]
        public Book GetBookById(Guid id)
        {
            var entity = Repository.GetById(id);
            if (entity != null)
            {
                return Repository.GetById(id);
            }

            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return null;
        }

        [HttpGet]
        public IEnumerable<Book> GetAllBooks()
        {
            return Repository.GetAll();
        }
    }
}
