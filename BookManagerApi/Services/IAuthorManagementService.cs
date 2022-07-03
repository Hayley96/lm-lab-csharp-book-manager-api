using System;
using BookManagerApi.Models;

namespace BookManagerApi.Services
{
	public interface IAuthorManagementService
	{
        List<Author> GetAllAuthors();
        Author Create(Author author);
        Author FindAuthorById(long id);
        bool AuthorExists(long id);
    }
}
