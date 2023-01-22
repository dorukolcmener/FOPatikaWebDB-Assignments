### [⬅️ Go Back](../../../README.md)

# .NET Author Controller Assignment

Assignment Link: [.NET Author Controller Assignment](https://app.patika.dev/courses/net-core/16-odev-author-controller-eklenmesi)

## ❓Question :

Implement AuthorController, Validators, Mappers with CRUD methods.

## ✏️Answer :

Please review the code for validator, mapper and command implementations of the author.

AuthorController:

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.AuthorOperations.Commands.CreateAuthor;
using WebApi.AuthorOperations.Commands.DeleteAuthor;
using WebApi.AuthorOperations.Commands.UpdateAuthor;
using WebApi.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.AuthorOperations.Queries.GetAuthors;
using WebApi.DBOperations;
using WebApi.Entities;
using static WebApi.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;
using static WebApi.AuthorOperations.Commands.UpdateAuthor.UpdateAuthorCommand;
using static WebApi.AuthorOperations.Queries.GetAuthorDetail.GetAuthorDetailQuery;
using static WebApi.AuthorOperations.Queries.GetAuthors.GetAuthorsQuery;

namespace WebApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Author
        [HttpGet]
        public async Task<ActionResult<List<AuthorsViewModel>>> GetAuthors()
        {
            var query = new GetAuthorsQuery(_context, _mapper);
            var authorList = query.Handle();
            return Ok(authorList);
        }

        // GET: api/Author/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorViewModel>> GetAuthor(int id)
        {
            var query = new GetAuthorDetailQuery(_context, _mapper);
            query.AuthorId = id;
            GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var author = query.Handle();
            return Ok(author);
        }

        // PUT: api/Author/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, UpdateAuthorModel author)
        {
            var command = new UpdateAuthorCommand(_context);
            command.AuthorId = id;
            command.model = author;
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return NoContent();
        }

        // POST: api/Author
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostAuthor(CreateAuthorModel author)
        {
            var command = new CreateAuthorCommand(_context, _mapper);
            command.model = author;
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        // DELETE: api/Author/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var command = new DeleteAuthorCommand(_context);
            command.AuthorId = id;
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        private bool AuthorExists(int id)
        {
            return (_context.Authors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../../assets/newPatikaLogo.svg" width=200/></a>
