// using AutoMapper;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.TokenOperations.Models;
using WebApi.UserOperations.Commands.CreateToken;
using WebApi.UserOperations.Commands.CreateUser;
using WebApi.UserOperations.Commands.RefreshToken;
using static WebApi.UserOperations.Commands.CreateUser.CreateUserCommand;

namespace WebApi.Controllers;

[Route("[controller]s")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;
    readonly IConfiguration _configuration;
    public UserController(IBookStoreDbContext context, IMapper mapper, IConfiguration configuration)
    {
        _context = context;
        _mapper = mapper;
        _configuration = configuration;
    }

    [HttpPost]
    public IActionResult AddUser([FromBody] CreateUserModel newUser)
    {
        CreateUserCommand command = new CreateUserCommand(_context, _mapper);
        command.model = newUser;
        // CreateUserCommandValidator validator = new CreateUserCommandValidator();
        // validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpPost("connect/token")]
    public ActionResult<Token> CreteToken([FromBody] CreateTokenModel model)
    {
        CreateTokenCommand command = new CreateTokenCommand(_context, _mapper, _configuration);
        command.model = model;
        // CreateTokenCommandValidator validator = new CreateTokenCommandValidator();
        // validator.ValidateAndThrow(command);
        var token = command.Handle();
        return token;
    }

    [HttpGet("refreshToken")]
    public ActionResult<Token> RefreshToken([FromQuery] string refreshToken)
    {
        RefreshTokenCommand command = new RefreshTokenCommand(_context, _mapper, _configuration);
        command.RefreshToken = refreshToken;
        var resultToken = command.Handle();
        return resultToken;
    }
}