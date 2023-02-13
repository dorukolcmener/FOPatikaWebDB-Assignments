using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApi.Entities;

namespace WebApi.TokenOperations.Models;

public class TokenHandler
{
    private readonly IConfiguration _configuration;
    public TokenHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public Token CreateAccessToken(User user)
    {
        Token tokenModel = new Token();
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        tokenModel.Expiration = DateTime.Now.AddMinutes(15);
        JwtSecurityToken token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            expires: tokenModel.Expiration,
            notBefore: DateTime.Now,
            signingCredentials: signingCredentials
        );
        tokenModel.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
        tokenModel.RefreshToken = CreateRefreshToken();
        return tokenModel;
    }

    public string CreateRefreshToken()
    {
        return Guid.NewGuid().ToString();
    }
}