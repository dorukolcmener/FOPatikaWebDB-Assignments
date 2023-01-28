using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.GetById;
using WebApi.BookOperations.GetByQuery;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;

namespace WebApi.Controllers;

[Route("[controller]s")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;

    public BookController(IBookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetBooks()
    {
        GetBooksQuery query = new GetBooksQuery(_context, _mapper);
        var result = query.Handle();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        GetByIdQuery query = new GetByIdQuery(_context, _mapper);
        query.BookId = id;
        var validator = new GetByIdValidator();
        validator.ValidateAndThrow(query);
        var result = query.Handle();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult AddBook([FromBody] CreateBookModel newBook)
    {
        CreateBookCommand command = new CreateBookCommand(_context, _mapper);
        command.model = newBook;
        CreateBookCommandValidator validator = new CreateBookCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel book)
    {
        var command = new UpdateBookCommand(_context);
        command.model = book;
        command.bookId = id;
        var validator = new UpdateBookValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var command = new DeleteBookCommand(_context);
        command.BookId = id;
        DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }
};