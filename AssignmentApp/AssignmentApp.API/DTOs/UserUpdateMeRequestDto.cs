using System.ComponentModel.DataAnnotations;

namespace AssignmentApp.API.DTOs;

public class UserUpdateMeRequestDto
{
    [StringLength(30,ErrorMessage = "Must be between 3 and 30 characters " , MinimumLength = 3)]
    public string Username { get; set; }
    
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
  
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }

    public string FullName { get; set; }
}