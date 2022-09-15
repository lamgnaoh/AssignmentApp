using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AssignmentApp.API.DTOs;
using AssignmentApp.API.Repository.Token;
using AssignmentApp.API.Utilities.Exception;
using AssignmentApp.Data.EF;
using AssignmentApp.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AssignmentApp.API.Repository.Users;

public class UserRepository : IUserRepository
{
    

    
    private readonly AssignmentAppDbContext _assignmentAppDbContext;
    private readonly ITokenHandler _iTokenHandler;

    public UserRepository( AssignmentAppDbContext assignmentAppDbContext , ITokenHandler iTokenHandler)
    {
        _assignmentAppDbContext = assignmentAppDbContext;
        _iTokenHandler = iTokenHandler;
    }
    public async Task<string> Authenticate(LoginRequest request)
    {
        var user = await _assignmentAppDbContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
        if (user == null || user.Password.Equals(request.Password) != true) 
        {
            return null;
        }
        var token = await _iTokenHandler.CreateTokenHanlder(user);
        return token;
    }

    public async Task<bool> Register(RegisterRequest request)
    {
        var checkUser = await _assignmentAppDbContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
        if (checkUser != null)
        {
            return false;
        }
        var user = new User()
        {
            Username = request.Username,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            MSSV = request.MSSV,
            FullName = request.FullName,
            RoleId = request.RoleId
        };
        await _assignmentAppDbContext.Users.AddAsync(user);
        await _assignmentAppDbContext.SaveChangesAsync();
        return true;
    }

    
}