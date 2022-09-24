using System.Security.Claims;
using System.Security.Cryptography;
using AssignmentApp.API.DTOs;
using AssignmentApp.API.Repository.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

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
        
        //Get list of claim
        
        return Ok(new
            {
                token = resultToken,
                fullname = HttpContext.User.FindFirstValue("Name")
            }
        );
        

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