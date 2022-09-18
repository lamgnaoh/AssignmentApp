using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AssignmentApp.API.DTOs;
using AssignmentApp.API.Repository.Token;
using AssignmentApp.API.Utilities.Exception;
using AssignmentApp.API.Utilities.Paging;
using AssignmentApp.Data.EF;
using AssignmentApp.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AssignmentApp.API.Repository.Users;

public class UserRepository : IUserRepository
{
    

    
    private readonly AssignmentAppDbContext _context;
    private readonly ITokenHandler _iTokenHandler;

    public UserRepository( AssignmentAppDbContext context , ITokenHandler iTokenHandler)
    {
        _context = context;
        _iTokenHandler = iTokenHandler;
    }
    public async Task<string> Authenticate(LoginRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
        if (user == null || user.Password.Equals(request.Password) != true) 
        {
            return null;
        }
        var token = await _iTokenHandler.CreateTokenHanlder(user);
        return token;
    }

    public async Task<bool> Register(RegisterRequest request)
    {
        var checkUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
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
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<User>> GetAll(UserPagingParameter pagingParameter)
    {
        var users = await _context.Users.OrderBy(u => u.Username)
            .Skip((pagingParameter.PageNumber - 1) * pagingParameter.PageSize).Take(pagingParameter.PageSize)
            .ToListAsync();
        return users;
    }

    public async Task<User> CreateUser(User createUser)
    {
        var newUser = new User()
        {
            Username = createUser.Username,
            Password = createUser.Password,
            PhoneNumber = createUser.Password,
            Email = createUser.Email,
            MSSV = createUser.MSSV,
            FullName = createUser.FullName,
            RoleId = createUser.RoleId
        };
         await _context.Users.AddAsync(newUser);
         await _context.SaveChangesAsync();
         return newUser;

    }

    public async Task<User> GetUserById(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> UpdateUser(User user , int userId)
    {
        var existingUser = await _context.Users.FindAsync(userId);
        if (existingUser == null)
        {
            throw new CustomException($"This assignment id is not found : {userId}");
            return null;
        }

        existingUser.Username= user.Username;
        existingUser.Password= user.Password;
        existingUser.PhoneNumber= user.PhoneNumber;
        existingUser.Email= user.Email;
        existingUser.MSSV= user.MSSV;
        existingUser.FullName= user.FullName;
        existingUser.RoleId= user.RoleId;
        await _context.SaveChangesAsync();
        return existingUser;
    }

    public async Task<User> DeleteUser(int id)
    {
        var deleteUser = await _context.Users.FindAsync(id);
        if (deleteUser == null)
        {
            throw new CustomException($"This user is not found with that id : {id}");
            return null;
        }

        var userClasses = await _context.UserClasses.Where(x => x.UserId == id).ToListAsync();
        _context.UserClasses.RemoveRange(userClasses);
        _context.Users.Remove(deleteUser);
        await _context.SaveChangesAsync();
        return deleteUser;
    }

    public async Task<List<User>> GetUserByUserName(string keyword)
    {
        if (string.IsNullOrEmpty(keyword))
        {
            return null;
        }
        var users = await _context.Users.Where(x=> x.Username.Contains(keyword)).ToListAsync();
        return users;
    }
}