using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoPrincipal.Data.DTO;
using ProjetoPrincipal.Models;
using ProjetoPrincipal.Services;

namespace ProjetoPrincipal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService _service;
        private readonly ILogger<PersonController> _logger;

        public BookController(IBookService service,
            ILogger<PersonController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Fetching all books");
            return Ok(_service.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Fetching book with ID {id}", id);
            return Ok(_service.FindById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookDTO book)
        {
            _logger.LogInformation("Creating new Book: {title}", book.Title);

            var createdBook = _service.Create(book);
            if (createdBook == null)
            {
                _logger.LogError("Failed to create book with title {firstName}", book.Title);
                return NotFound();
            }
            return Ok(createdBook);
        }

        [HttpPut]
        public IActionResult Put([FromBody] BookDTO book)
        {
            _logger.LogInformation("Updating book with ID {id}", book.Id);

            var bookUpdated = _service.Update(book);
            if (bookUpdated == null)
            {
                _logger.LogError("Failed to update book with ID {id}", book.Id);
                return NotFound();
            }
            _logger.LogDebug("Book updated successfully: {title}", book.Title);
            return Ok(bookUpdated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Deleting book with ID {id}", id);
            _service.Delete(id);
            _logger.LogDebug("Book with ID {id} deleted successfully", id);
            return NoContent();
        }
    }
}
