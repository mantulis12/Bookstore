using Bookstore.Models;
using System.Xml.Linq;

namespace Bookstore.Services
{
    public class AuthorService : IAuthorService
    {
        static List<Author> Authors { get; }
        static int nextId = 3;

        static AuthorService()
        {
            Authors = new List<Author>
        {
            new Author{ Id = 1, Name = "Joanne", Surname = "Rowling"},
            new Author{ Id = 2, Name = "Puppy", Surname = "Puppy"}
        };
        }

        public List<Author> GetAll() => Authors;

        public Author? Get(int id) => Authors.FirstOrDefault(p => p.Id == id);

        public void Add(Author pizza)
        {
            pizza.Id = nextId++;
            Authors.Add(pizza);
        }

        public void Delete(int id)
        {
            var pizza = Get(id);

            if (pizza is null) return;

            Authors.Remove(pizza);
        }


        public void Update(Author author)
        {
            var index = Authors.FindIndex(p => p.Id == author.Id);

            if (index < 0) return;
        }
    }
}
