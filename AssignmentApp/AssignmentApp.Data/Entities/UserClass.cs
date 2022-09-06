using AssignmentApp.Data.Enums;

namespace AssignmentApp.Data.Entities;

public class UserClass
{
    public Guid UserId { get; set; }
    public Guid ClassId { get; set; }
}