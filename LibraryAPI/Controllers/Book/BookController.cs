using LibraryAPI.Commands;
using LibraryAPI.Entities.DTOs.Book;
using LibraryAPI.Models.Book;
using LibraryAPI.Queries;
using LibraryAPI.Queries.GetBookById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BookController> _logger;

        public BookController(IMediator mediator, ILogger<BookController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks([FromQuery] BookSearchModel searchModel)
        {
            var query = new GetBooksQuery(searchModel);
            var books = await _mediator.Send(query);
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBook(int id)
        {
            var query = new GetBookByIdQuery(id);
            var book = await _mediator.Send(query);

            if (book == null)
            {
                _logger.LogWarning("Book with ID {Id} not found.", id);
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<BookDTO>> PostBook([FromBody] CreateBookDTO dto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for creating a book.");
                return BadRequest(ModelState);
            }

            var command = new AddBookCommand(dto);
            var book = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, [FromBody] UpdateBookDTO dto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for updating book with ID {Id}.", id);
                return BadRequest(ModelState);
            }

            try
            {
                var command = new UpdateBookCommand(id, dto);
                await _mediator.Send(command);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Book with ID {Id} not found.", id);
                return NotFound("Book not found.");
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Invalid status transition for book with ID {Id}.", id);
                return BadRequest("Invalid status transition.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                var command = new DeleteBookCommand(id);
                await _mediator.Send(command);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Book with ID {Id} not found.", id);
                return NotFound("Book not found.");
            }
        }
    }
}