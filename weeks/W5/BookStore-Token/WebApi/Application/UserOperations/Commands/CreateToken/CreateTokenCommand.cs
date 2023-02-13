using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.TokenOperations.Models;

namespace WebApi.UserOperations.Commands.CreateToken;

public class CreateTokenCommand
{
    public CreateTokenModel model { get; set; }
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public CreateTokenCommand(IBookStoreDbContext context, IMapper mapper, IConfiguration configuration)
    {
        _context = context;
        _mapper = mapper;
        _configuration = configuration;
    }

    public Token Handle()
    {
        var user = _context.Users.SingleOrDefault(x => x.Email == model.Email && x.Password == model.Password);
        if (user is null)
            throw new InvalidOperationException("Wrong username or password.");

        var tokenHandler = new TokenHandler(_configuration);
        Token token = tokenHandler.CreateAccessToken(user);
        user.RefreshToken = token.RefreshToken;
        user.RefreshTokenExpiryTime = token.Expiration.AddMinutes(3);
        _context.SaveChanges();

        return token;
    }
}

public class CreateTokenModel
{
    public string Email { get; set; }
    public string Password { get; set; }
}