using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("[controller]s")]
[ApiController]
public class BookController : ControllerBase
{
    private static List<Book> BookList = new List<Book>()
    {
        new Book {
            Id = 1,
            Title = "The Hobbit",
            GenreId = 1,
            PageCount = 295,
            PublishDate = new DateTime(1937, 9, 21)
        },
        new Book {
            Id = 2,
            Title = "The Lord of the Rings",
            GenreId = 1,
            PageCount = 1216,
            PublishDate = new DateTime(1954, 7, 29)
        },
        new Book {
            Id = 3,
            Title = "The Silmarillion",
            GenreId = 1,
            PageCount = 429,
            PublishDate = new DateTime(1977, 9, 15)
        }
    };

    [HttpGet]
    public List<Book> GetBooks()
    {
        var bookList = BookList.OrderBy(b => b.Id).ToList();
        return bookList;
    }

    [HttpGet("{id}")]
    public Book? GetById(int id)
    {
        var book = BookList.Where(b => b.Id == id).SingleOrDefault();
        return book;
    }

    [HttpPost]
    public IActionResult AddBook([FromBody] Book book)
    {
        if (BookList.SingleOrDefault(b => b.Title == book.Title) != null)
        {
            // throw new Exception("Book already exists");
            return BadRequest("Book already exists");
        }

        BookList.Add(book);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, [FromBody] Book book)
    {
        var bookToUpdate = BookList.SingleOrDefault(b => b.Id == id);
        if (bookToUpdate == null)
        {
            return NotFound();
        }

        bookToUpdate.GenreId = book.GenreId != default ? book.GenreId : bookToUpdate.GenreId;
        bookToUpdate.PageCount = book.PageCount != default ? book.PageCount : bookToUpdate.PageCount;
        bookToUpdate.PublishDate = book.PublishDate != default ? book.PublishDate : bookToUpdate.PublishDate;
        bookToUpdate.Title = book.Title != default ? book.Title : bookToUpdate.Title;
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var bookToDelete = BookList.SingleOrDefault(b => b.Id == id);
        if (bookToDelete == null)
        {
            return NotFound();
        }

        BookList.Remove(bookToDelete);
        return Ok();
    }
};