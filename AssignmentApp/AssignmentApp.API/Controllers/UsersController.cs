using System.Security.Claims;
using AssignmentApp.API.DTOs;
using AssignmentApp.API.Repository.UserRoles;
using AssignmentApp.API.Repository.Users;
using AssignmentApp.API.Utilities.Paging;
using AssignmentApp.Data.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "1")]
    public async Task<IActionResult> GetAll([FromQuery]UserPagingParameter pagingParameter)
    {
        var users = await _userRepository.GetAll(pagingParameter);
        var usersDto = _mapper.Map<List<UserDto>>(users);
        return Ok(usersDto);
    }
    [HttpGet]
    [Route("{id:int}")]
    [ActionName("GetUserById")]
    [Authorize]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userRepository.GetUserById(id);
        var userDto = _mapper.Map<UserDto>(user);
        return Ok(userDto);
    }
    [HttpPost]
    [Authorize(Roles = "1")]
    public async Task<IActionResult> CreateUser([FromBody] UserCreateRequestDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var newUser = new User()
        {
            Username = request.Username,
            Password = request.Password,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            MSSV = request.MSSV,
            FullName = request.FullName
        };
        var RoleIds = request.RoleID;
        newUser = await _userRepository.CreateUser(newUser,RoleIds);
        var newUserDto = _mapper.Map<UserDto>(newUser);
        return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUserDto);
    }

    [HttpPut]
    [Route("{id:int}")]
    [Authorize(Roles = "1")]
    // admin update user info
    public async Task<IActionResult> UpdateUser([FromRoute] int id,
        [FromBody] UserUpdateRequestDto userUpdateRequestDto)
    {
        // convert dto to domain model 
        var updateUser = await _userRepository.GetUserById(id);
        if (updateUser == null)
        {
            return NotFound();
        }

        updateUser = new User()
        {
            Username = userUpdateRequestDto.Username,
            Password = updateUser.Password,
            Email = userUpdateRequestDto.Email,
            PhoneNumber = userUpdateRequestDto.PhoneNumber,
            FullName = userUpdateRequestDto.FullName,
            MSSV = userUpdateRequestDto.MSSV,
        };

        updateUser = await _userRepository.UpdateUser(updateUser, id); 
        if (updateUser == null)
        {
            return BadRequest();
        }

        var updateUserDto = _mapper.Map<UserDto>(updateUser);
        return Ok(updateUserDto);
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    [Authorize(Roles = "1")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        //get assignment from database , if null  return not found 
        var deleteUser = await _userRepository.DeleteUser(id);
        if (deleteUser == null)
        {
            return BadRequest();
        }
        // convert response to Dto
        var deleteUserDto = _mapper.Map<UserDto>(deleteUser);
        return Ok(deleteUserDto);
    }

    [HttpGet]
    [Route("search")]
    [Authorize]
    public async Task<IActionResult> GetUserByUsername([FromQuery]string keyword)
    {
        var users = await _userRepository.GetUserByUserName(keyword);
        if (users == null)
        {
            return NotFound($"Cannot find username with the keyword: {keyword}");
        }

        var userDto = _mapper.Map<List<UserDto>>(users);
        return Ok(userDto);
    }
    
    // Update me- khong the update role
    [HttpPost]
    [Route("me")]
    [Authorize]
    public async Task<IActionResult> UpdateMe([FromBody] UserUpdateMeRequestDto updateRequestDto)
    {
        var idClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        var id = Int32.Parse(idClaim);
        var updateUser = await _userRepository.GetUserById(id);
        if (updateUser == null)
        {
            return NotFound($"No User with id {id}");
        }
        updateUser = new User()
        {
            Username = updateRequestDto.Username,
            Password = updateRequestDto.Password,
            Email = updateRequestDto.Email,
            PhoneNumber = updateRequestDto.PhoneNumber,
            FullName = updateRequestDto.FullName,
            MSSV =updateUser.MSSV
        };
        updateUser = await _userRepository.UpdateUser(updateUser, id);
        if (updateUser == null)
        {
            return BadRequest("Cannot update user");
        }

        var updateUserDto = _mapper.Map<UserDto>(updateUser);
        return Ok(updateUserDto);
    }
}