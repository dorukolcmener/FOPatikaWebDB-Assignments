using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.GetByQuery;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.GetByQuery.GetByIdQuery;
using static WebApi.BookOperations.UpdateBook.UpdateBookQuery;

namespace WebApi.Controllers;

[Route("[controller]s")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly BookStoreDbContext _context;

    public BookController(BookStoreDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetBooks()
    {
        GetBooksQuery query = new GetBooksQuery(_context);
        var result = query.Handle();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public BookViewModel? GetById(int id)
    {
        GetByIdQuery query = new GetByIdQuery(_context);
        var result = query.Handle(id);
        return result;
    }

    [HttpPost]
    public IActionResult AddBook([FromBody] CreateBookModel newBook)
    {
        try
        {
            CreateBookCommand command = new CreateBookCommand(_context);
            command.model = newBook;
            command.Handle();
        }
        catch (InvalidOperationException exception)
        {
            return BadRequest(exception.Message);
        }

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel book)
    {
        try
        {
            var query = new UpdateBookQuery(_context);
            query.model = book;
            query.Handle();
        }
        catch (InvalidOperationException exception)
        {

            return BadRequest(exception.Message);
        }
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        try
        {
            var query = new DeleteBookQuery(_context);
            query.BookId = id;
            query.Handle();
        }
        catch (InvalidOperationException exception)
        {
            return BadRequest(exception.Message);
        }
        return Ok();
    }
};