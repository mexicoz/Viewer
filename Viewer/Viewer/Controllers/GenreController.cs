using Microsoft.AspNetCore.Mvc;
using Viewer.Interface;
using Viewer.Models;

namespace Viewer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : Controller
    {
        private readonly IGenreRepository _genreRepository;

        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Genre>))]
        public IActionResult GetGenres()
        {
            var genres = _genreRepository.GetGenres();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(genres);
        }
      
        [HttpGet("{genreId}/books")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        [ProducesResponseType(400)]
        public IActionResult GetBooksByGenre(int genreId)
        {
            if (!_genreRepository.HasGenre(genreId))
            {
                return NotFound();
            }
            var books = _genreRepository.GetBooksByGenre(genreId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(books);
        }

        [HttpGet("{genreId}")]
        [ProducesResponseType(200, Type = typeof(Genre))]
        [ProducesResponseType(400)]
        public IActionResult GetGenre(int genreId)
        {
            if (!_genreRepository.HasGenre(genreId))
            {
                return NotFound();
            }
            var genre = _genreRepository.GetGenre(genreId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(genre);
        }
    }
}
