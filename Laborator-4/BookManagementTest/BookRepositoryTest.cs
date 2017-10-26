using System.Collections.Generic;
using BookManagement;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookManagementTest
{
    [TestClass]
    public class BookRepositoryTest
    {
        [TestMethod]
        public void Give_ABookRepositoryInstance_When_RetriveAllBooks_QuerryIsCalled_Then_ShouldHave10Books()
        {
            var books = CreateSut();
            books.RetriveAllBooks_Querry().Count.Should().Be(10);
        }

        [TestMethod]
        public void Give_ABookRepositoryInstance_When_RetriveAllOrderByYearDescending_QuerryIsCalled_Then_FirstBookShouldBeMorometii()
        {
            var books = CreateSut();
            books.RetriveAllOrderByYearDescending_Querry()[0].Title.Should().Be("Morometii");
        }

        [TestMethod]
        public void Give_ABookRepositoryInstance_When_RetriveAllOrderByYearAscending_QuerryIsCalled_Then_FirstBookShouldBeMizerabilii()
        {
            var books = CreateSut();
            books.RetriveAllOrderByYearAscending_Querry()[0].Title.Should().Be("Mizerabilii");
        }

        [TestMethod]
        public void Give_ABookRepositoryInstance_When_RetriveAllOrderByPriceAscending_QuerryIsCalled_Then_FirstBookShouldBePeAripileVantului()
        {
            var books = CreateSut();
            books.RetriveAllOrderByPriceAscending_Querry()[0].Title.Should().Be("Pe aripile vantului");
        }

        [TestMethod]
        public void Give_ABookRepositoryInstance_When_RetriveAllOrderByPriceDescending_QuerryIsCalled_Then_FirstBookShouldBeConteleDeMonteCristo()
        {
            var books = CreateSut();
            books.RetriveAllOrderByPriceDescending_Querry()[0].Title.Should().Be("Contele de Monte Cristo");
        }

        [TestMethod]
        public void Give_ABookRepositoryInstance_When_RetriveAllBooksGroupedByGenre_QuerryIsCalled_Then_ShouldHave3Genre()
        {
            var books = CreateSut();
            books.RetriveAllBooksGroupedByGenre_Querry().Keys.Count.Should().Be(3);
        }

        [TestMethod]
        public void Give_ABookRepositoryInstance_When_RetriveAllBooks_MethodSyntaxIsCalled_Then_ShouldHave10Books()
        {
            var books = CreateSut();
            books.RetriveAllBooks_Querry().Count.Should().Be(10);
        }

        [TestMethod]
        public void Give_ABookRepositoryInstance_When_RetriveAllOrderByYearDescending_MethodSyntaxIsCalled_Then_FirstBookShouldBeMorometii()
        {
            var books = CreateSut();
            books.RetriveAllOrderByYearDescending_Querry()[0].Title.Should().Be("Morometii");
        }

        [TestMethod]
        public void Give_ABookRepositoryInstance_When_RetriveAllOrderByYearAscending_MethodSyntaxIsCalled_Then_FirstBookShouldBeMizerabilii()
        {
            var books = CreateSut();
            books.RetriveAllOrderByYearAscending_Querry()[0].Title.Should().Be("Mizerabilii");
        }

        [TestMethod]
        public void Give_ABookRepositoryInstance_When_RetriveAllOrderByPriceAscending_MethodSyntaxIsCalled_Then_FirstBookShouldBePeAripileVantului()
        {
            var books = CreateSut();
            books.RetriveAllOrderByPriceAscending_Querry()[0].Title.Should().Be("Pe aripile vantului");
        }

        [TestMethod]
        public void Give_ABookRepositoryInstance_When_RetriveAllOrderByPriceDescending_MethodSyntaxIsCalled_Then_FirstBookShouldBeConteleDeMonteCristo()
        {
            var books = CreateSut();
            books.RetriveAllOrderByPriceDescending_Querry()[0].Title.Should().Be("Contele de Monte Cristo");
        }

        [TestMethod]
        public void Give_ABookRepositoryInstance_When_RetriveAllBooksGroupedByGenre_MethodSyntaxIsCalled_Then_ShouldHave3Genre()
        {
            var books = CreateSut();
            books.RetriveAllBooksGroupedByGenre_Querry().Keys.Count.Should().Be(3);
        }

        public BookRepository CreateSut()
        {
            BookRepository books = new BookRepository(new List<Book>()
            {
                new Book("Pe aripile vantului",2007,22,"Roman istoric"),
                new Book("Mandrie si prejudecata",2000,202,"Roman istoric"),
                new Book("Frankenstein",2003,51,"Roman strain"),
                new Book("Crima si pedeapsa",2002,145,"Roman romanesc"),
                new Book("Codul lui Da Vinci",2007,152,"Roman istoric"),
                new Book("Morometii",2017,71,"Roman romanesc"),
                new Book("Cel mai iubit dintre pamanteni",2013,122,"Roman romanesc"),
                new Book("Contele de Monte Cristo",1996,465,"Roman strain"),
                new Book("Mizerabilii",1992,157,"Roman strain"),
                new Book("Fratii Jderi",2001,78,"Roman strain")
            });
            return books;
        }

        [TestMethod]
        public void Give_ANewBookInstance_When_SettingValidParameters_Then_TheValuesShouldBeSet()
        {
            var book = new Book("Fratii Jderi", 2001, 78, "Roman strain");
            book.Id.Should().NotBeEmpty();
            book.Title.Should().Be("Fratii Jderi");
            book.Year.Should().Be(2001);
            book.Price.Should().Be(78);
            book.Genere.Should().Be("Roman strain");
        }

    }
}
