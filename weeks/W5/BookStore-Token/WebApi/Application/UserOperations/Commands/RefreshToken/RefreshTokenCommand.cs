using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.TokenOperations.Models;

namespace WebApi.UserOperations.Commands.RefreshToken;

public class RefreshTokenCommand
{
    public string RefreshToken { get; set; }
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public RefreshTokenCommand(IBookStoreDbContext context, IMapper mapper, IConfiguration configuration)
    {
        _context = context;
        _mapper = mapper;
        _configuration = configuration;
    }

    public Token Handle()
    {
        var user = _context.Users.SingleOrDefault(x => x.RefreshToken == RefreshToken);
        if (user is null)
            throw new InvalidOperationException("Invalid token.");
        if (user.RefreshTokenExpiryTime < DateTime.Now)
            throw new InvalidOperationException("Token has expired.");

        var tokenHandler = new TokenHandler(_configuration);
        Token token = tokenHandler.CreateAccessToken(user);
        user.RefreshToken = token.RefreshToken;
        user.RefreshTokenExpiryTime = token.Expiration.AddMinutes(3);
        _context.SaveChanges();

        return token;
    }
}