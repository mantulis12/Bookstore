using Bookstore.Models;
using Bookstore.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
    public class AuthorController : ControllerBase
    {
        private AuthorService _authorService;
        public AuthorController()
        {
            this._authorService = new AuthorService();
        }

        //GET
        [HttpGet("author")] public ActionResult<List<Author>> GetAll() => _authorService.GetAll();

        [HttpGet("author/{id}")]
        public ActionResult<Author> Get(int id)
        {
            var author = _authorService.Get(id);

            return author == null ? NotFound() : Ok(author);
        }

        [HttpPost("author")]
        public IActionResult Create(Author author)
        {
            _authorService.Add(author);

            return CreatedAtAction(nameof(Create), new { id = author.Id }, author);
        }

        [HttpPut("author/{id}")]
        public IActionResult Update(int id, Author author)
        {
            if (author.Id != id) return BadRequest();

            var existingAuthor = _authorService.Get(id);

            if (existingAuthor == null) return NotFound();

            _authorService.Update(author);

            return Ok(author);
        }

        [HttpDelete("author/{id}")]
        public IActionResult Delete(int id)
        {
            var author = _authorService.Get(id);

            if (author == null) return NotFound();

            _authorService.Delete(id);

            return NoContent();
        }
    }
}
