﻿
namespace AssignmentApp.Data.Entities;

public class UserRole
{
    public int UserId { get; set; }
    public User User { get; set; }
    public int RoleId { get; set; }
    public AppRole AppRole { get; set; }
}