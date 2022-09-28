using System.ComponentModel.DataAnnotations;

namespace AssignmentApp.API.DTOs;

public class UserUpdateRequestDto
{
    [StringLength(30, ErrorMessage = "Must be between 3 and 30 characters ", MinimumLength = 3)]
    public string Username { get; set; }

    [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 8)]
    public string Password { get; set; }

    public string PhoneNumber { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }

    public string FullName { get; set; }
    public string MSSV { get; set; }

}