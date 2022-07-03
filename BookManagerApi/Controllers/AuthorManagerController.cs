using BookManagerApi.Helpers;
using BookManagerApi.Models;
using BookManagerApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookManagerApi.Controllers
{
    [Route("api/v1/author")]
    [ApiController]
    public class AuthorManagerController : ControllerBase
    {
        private readonly IAuthorManagementService _authorManagementService;
        public AuthorManagerController(IAuthorManagementService authorManagementService)
        {
            _authorManagementService = authorManagementService;
        }

        // GET: api/v1/author/5
        [HttpGet("{id}")]
        public ActionResult<Author> GetAuthorById(long id)
        {
            var author = _authorManagementService.FindAuthorById(id);
            if (author != null)
                return author;
            return Validators.Result(HttpStatusCode.NotFound, $"Author with id {id} not found in our authors...Please try again");
        }

        // GET: api/v1/author
        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAuthors()
        {
            return _authorManagementService.GetAllAuthors();
        }

        // POST: api/v1/author
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Author> AddAuthor(Author author)
        {
            if (_authorManagementService.AuthorExists(author.Id))
            {
                return Validators.Result(HttpStatusCode.BadRequest, $"Author with id {author.Id} already exists...Please try again");
            }
            _authorManagementService.Create(author);
            return CreatedAtAction(nameof(GetAuthorById), new { id = author.Id }, author);
        }
    }
}