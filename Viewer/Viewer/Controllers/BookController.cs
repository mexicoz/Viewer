using Microsoft.AspNetCore.Mvc;
using Viewer.Interface;
using Viewer.Models;

namespace Viewer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        public IActionResult GetBooks()
        {
            var books = _bookRepository.GetBooks();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(books);
        }
        [HttpGet("{bookId}/author")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        [ProducesResponseType(400)]
        public IActionResult GetAuthorByBook(int bookId)
        {
            if (!_bookRepository.HasBook(bookId))
            {
                return NotFound();
            }
            var author = _bookRepository.GetBookAuthor(bookId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(author);
        }
        [HttpGet("{bookId}/genre")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        [ProducesResponseType(400)]
        public IActionResult GetGenreByBook(int bookId)
        {
            if (!_bookRepository.HasBook(bookId))
            {
                return NotFound();
            }
            var genre = _bookRepository.GetBookGenre(bookId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(genre);
        }
    }
}
