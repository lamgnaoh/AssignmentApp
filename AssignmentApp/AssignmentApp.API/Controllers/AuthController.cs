using System.Security.Claims;
using AssignmentApp.API.DTOs;
using AssignmentApp.API.Repository.Users;
using AssignmentApp.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : Controller
{
    private readonly IUserRepository _userRepository;

    public AuthController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Authenticate([FromBody] LoginRequest loginRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var resultToken = await _userRepository.Authenticate(loginRequest);
        if (string.IsNullOrEmpty(resultToken))
        {
            return BadRequest("Email or password is not correct");
        }

        var userRole ="";
        if (User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value == "1")
        {
            userRole = "teacher";
        }else if (User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value == "2")
        {
            userRole = "student";
        }
        else
        {
            userRole = "admin";
        }
        
        return Ok(new {token = resultToken , name = User.Claims.FirstOrDefault(x=> x.Type == ClaimTypes.Name)?.Value, role = userRole});
        

    }
    
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var result = await _userRepository.Register(registerRequest);
        if (result == false)
        {
            return BadRequest("Register unsuccessfull");
        }

        return Ok();
    }
}