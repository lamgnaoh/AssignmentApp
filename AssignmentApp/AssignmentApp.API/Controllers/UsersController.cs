using AssignmentApp.API.DTOs;
using AssignmentApp.API.Repository.Users;
using AssignmentApp.API.Utilities.Paging;
using AssignmentApp.Data.Entities;
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
    [HttpGet]
    [Route("{id:int}")]
    [ActionName("GetUserById")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userRepository.GetUserById(id);
        var userDto = _mapper.Map<UserDto>(user);
        return Ok(userDto);
    }
    [HttpPost]
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
            FullName = request.FullName,
            RoleId = request.RoleId
        };
        newUser = await _userRepository.CreateUser(newUser);
        var newUserDto = _mapper.Map<UserDto>(newUser);
        return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUserDto);
    }

    [HttpPut]
    [Route("{id:int}")]
    // admin update user
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
            RoleId = userUpdateRequestDto.RoleId
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
}