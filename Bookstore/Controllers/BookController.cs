using Bookstore.Models;
using Bookstore.Services;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
    public class BookController : ControllerBase
    {
        private BookService _bookService;
        public BookController()
        {
            this._bookService = new BookService();
        }

        //GET
        [HttpGet("book")] public ActionResult<List<Book>> GetAll() => _bookService.GetAll();

        [HttpGet("book/{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = _bookService.Get(id);

            return book == null ? NotFound() : Ok(book);
        }

        [HttpGet("/book/author/{AuthorId}")]
        public ActionResult<Book> GetByAuthor(int AuthorId)
        {
            var Books = _bookService.GetByAuthor(AuthorId);

            return Books == null ? NotFound() : Ok(Books);
        }

        [HttpPost("book")]
        public IActionResult Create(Book book)
        {
            _bookService.Add(book);

            return CreatedAtAction(nameof(Create), new { id = book.Id }, book);
        }

        [HttpPut("book/{id}")]
        public IActionResult Update(int id, Book book)
        {
            if (book.Id != id) return BadRequest();

            var existingBook = _bookService.Get(id);

            if (existingBook == null) return NotFound();

            _bookService.Update(book);

            return Ok(book);
        }

        [HttpDelete("book/{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookService.Get(id);

            if (book == null) return NotFound();

            _bookService.Delete(id);

            return NoContent();
        }
    }
}
