using Bookstore.Models;
using System.Linq;
using System.Xml.Linq;

namespace Bookstore.Services
{
    public class BookService
    {
        static List<Book> Books { get; }
        static int nextId = 3;

        static BookService()
        {
            Books = new List<Book>
        {
            new Book{ Id = 1, Name = "Harry Potter", AuthorId = 1},
            new Book{ Id = 2, Name = "Puppy", AuthorId = 2},
            new Book{ Id = 3, Name = "Harry Potter 2", AuthorId = 1},
            new Book{ Id = 4, Name = "Harry Potter 3", AuthorId = 1},
            new Book{ Id = 5, Name = "Puppy 2", AuthorId = 2}
        };
        }

        public List<Book> GetAll()
        {
            var BookList = Books;
            var AuthorService = new AuthorService();

            foreach (var book in BookList)
            {
                book.Author = AuthorService.Get(book.AuthorId);
            }

            return BookList;
        }

        public Book? Get(int id)
        {
            var AuthorService = new AuthorService();
            var book = Books.FirstOrDefault(p => p.Id == id);
            if (book == null)
            {
                return null;
            }

            book.Author = AuthorService.Get(book.AuthorId);

            return book;

        }
        public List<Book>? GetByAuthor(int id)
        {
            return Books.Where(p => p.AuthorId == id).ToList();
        }

        public void Add(Book book)
        {
            book.Id = nextId++;
            Books.Add(book);
        }

        public void Delete(int id)
        {
            var book = Get(id);

            if (book is null) return;

            Books.Remove(book);
        }


        public void Update(Book book)
        {
            var index = Books.FindIndex(p => p.Id == book.Id);

            if (index < 0) return;
        }
    }
}
