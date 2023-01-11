using Bookstore.Models;

namespace Bookstore.Services
{
    public interface IBookService
    {

        public List<Book> GetAll();

        public Book? Get(int id);

        public List<Book>? GetByAuthor(int id);

        public void Add(Book book);

        public void Delete(int id);

        public void Update(Book book);
    }
}
