using Microsoft.AspNetCore.Mvc;
using Viewer.Interface;
using Viewer.Models;

namespace Viewer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Author))]
        public IActionResult GetAuthors()
        {
            var authors = _authorRepository.GetAuthors();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(authors);
        }
    }
}
