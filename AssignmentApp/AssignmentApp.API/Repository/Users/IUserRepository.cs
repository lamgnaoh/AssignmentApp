using AssignmentApp.API.DTOs;
using AssignmentApp.API.Utilities.Paging;
using AssignmentApp.Data.Entities;

namespace AssignmentApp.API.Repository.Users;

public interface IUserRepository
{
    Task<string> Authenticate(LoginRequest request);
    Task<bool> Register(RegisterRequest request);

    Task<List<User>> GetAll(UserPagingParameter pagingParameter);
}