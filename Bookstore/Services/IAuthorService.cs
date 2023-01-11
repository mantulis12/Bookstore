using Bookstore.Models;

namespace Bookstore.Services
{
    public interface IAuthorService
    {
        public List<Author> GetAll();

        public Author? Get(int id);

        public void Add(Author pizza);

        public void Delete(int id);

        public void Update(Author author);
    }
}
