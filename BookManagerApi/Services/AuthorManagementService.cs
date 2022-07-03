using BookManagerApi.Data;
using BookManagerApi.Models;

namespace BookManagerApi.Services
{
    public class AuthorManagementService : IAuthorManagementService
    {
        private readonly ModelsContext _context;

        public AuthorManagementService(ModelsContext context)
        {
            _context = context;
        }

        public List<Author> GetAllAuthors()
        {
            var authors = _context.Authors!.ToList();
            return authors;
        }

        public Author Create(Author author)
        {
            _context.Add(author);
            _context.SaveChanges();
            return author;
        }

        public Author FindAuthorById(long id)
        {
            var author = _context.Authors!.Find(id);
            return author!;
        }

        public bool AuthorExists(long id)
        {
            return _context.Authors!.Any(a => a.Id == id);
        }
    }
}