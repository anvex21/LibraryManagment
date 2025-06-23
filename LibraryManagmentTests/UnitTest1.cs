using LibraryManagment.Controllers;
using LibraryManagment.Data;
using LibraryManagment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagmentTests
{
    public class Tests
    {
        private LibraryDbContext _context;
        private BooksController _controller;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseSqlServer(databaseName: "LibraryTestDb")
                .Options;

            _context = new LibraryDbContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _context.Books.AddRange(
                new Book { Id = 1, Title = "Book One", Author = "Author A", Year = 2020, Genre = "Fiction" },
                new Book { Id = 2, Title = "Book Two", Author = "Author B", Year = 2021, Genre = "Sci-Fi" }
            );
            _context.SaveChanges();

            _controller = new BooksController(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _controller?.Dispose(); 
            _context?.Dispose();
        }


        [Test]
        public async Task Index_ReturnsViewWithBooks()
        {
            var result = await _controller.Index(null) as ViewResult;
            var model = result?.Model as BookIndexViewModel;

            Assert.IsNotNull(result);
            Assert.IsNotNull(model);
            Assert.AreEqual(2, model.Books.Count);
        }

        [Test]
        public async Task Details_ReturnsCorrectBook()
        {
            var result = await _controller.Details(1) as ViewResult;
            var book = result?.Model as Book;

            Assert.IsNotNull(book);
            Assert.AreEqual("Book One", book.Title);
        }

        [Test]
        public async Task Create_AddsNewBook()
        {
            var newBook = new Book { Id = 3, Title = "Book Three", Author = "Author C", Year = 2022, Genre = "Drama" };
            var result = await _controller.Create(newBook) as RedirectToActionResult;

            Assert.AreEqual(3, _context.Books.Count());
            Assert.AreEqual("Index", result.ActionName);
        }

        [Test]
        public async Task Edit_UpdatesBook()
        {
            var updated = new Book { Id = 1, Title = "Updated Title", Author = "Author A", Year = 2020, Genre = "Fiction" };
            var result = await _controller.Edit(1, updated) as RedirectToActionResult;

            var book = _context.Books.Find(1);
            Assert.AreEqual("Updated Title", book.Title);
            Assert.AreEqual("Index", result.ActionName);
        }

        [Test]
        public async Task DeleteConfirmed_RemovesBook()
        {
            var result = await _controller.DeleteConfirmed(1) as RedirectToActionResult;

            Assert.AreEqual(1, _context.Books.Count());
            Assert.AreEqual("Index", result.ActionName);
        }
    }
}