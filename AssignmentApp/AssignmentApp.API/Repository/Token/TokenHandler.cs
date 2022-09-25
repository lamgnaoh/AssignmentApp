using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AssignmentApp.Data.Entities;
using Microsoft.IdentityModel.Tokens;

namespace AssignmentApp.API.Repository.Token;

public class TokenHandler : ITokenHandler
{
    private readonly IConfiguration _config;

    public TokenHandler(IConfiguration config)
    {
        _config = config;
    }
    public async Task<string> CreateTokenHanlder(User user,List<UserRole> userRoles)
    {
       
        var claims = new List<Claim>();
        claims.Add(new Claim("Email", user.Email));
        claims.Add(new Claim("Name", user.FullName));
        foreach (var role in userRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role , role.RoleId.ToString()));
        }
        claims.Add(new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()));
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMonths(3),
            signingCredentials: creds);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}