using AssignmentApp.API.DTOs;
using AssignmentApp.API.Repository.Users;
using AssignmentApp.API.Utilities.Paging;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController:Controller
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UsersController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery]UserPagingParameter pagingParameter)
    {
        var users = await _userRepository.GetAll(pagingParameter);
        var usersDto = _mapper.Map<List<UserDto>>(users);
        return Ok(usersDto);
    }
    
    
}