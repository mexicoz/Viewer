using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Viewer.Dto;
using Viewer.Interface;
using Viewer.Models;

namespace Viewer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Author>))]
        public IActionResult GetAuthors()
        {
            var authors =_mapper.Map<List<AuthorDto>>(_authorRepository.GetAuthors());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(authors);
        }
        [HttpGet("{authorId}/books")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        [ProducesResponseType(400)]
        public IActionResult GetBooksByAuthor(int authorId)
        {
            if (!_authorRepository.HasAuthor(authorId))
            {
                return NotFound();
            }
            var books = _authorRepository.GetBooksByAuthor(authorId);
           
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(books);
        }

        [HttpGet("{authorId}")]
        [ProducesResponseType(200, Type = typeof(Author))]
        [ProducesResponseType(400)]
        public IActionResult GetAuthor(int authorId)
        {
            if (!_authorRepository.HasAuthor(authorId))
            {
                return NotFound();
            }
            var author = _mapper.Map<AuthorDto>(_authorRepository.GetAuthor(authorId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(author);
        }
        [HttpGet("{authorId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetAuthorRating(int authorId)
        {
            if (!_authorRepository.HasAuthor(authorId))
            {
                return NotFound();
            }
            var rating = _authorRepository.GetAuthorRating(authorId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(rating);
        }
    }
}
