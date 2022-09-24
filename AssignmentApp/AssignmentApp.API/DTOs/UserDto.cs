﻿namespace AssignmentApp.API.DTOs;

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string? MSSV { get; set; }
    public string FullName { get; set; }
    
}