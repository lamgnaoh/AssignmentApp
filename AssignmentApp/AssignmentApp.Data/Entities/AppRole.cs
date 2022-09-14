using AssignmentApp.Data.Enums;

namespace AssignmentApp.Data.Entities;

public class AppRole
{
    public int RoleId { get; set; }
    public Role role { get; set; }
    
    //navigation properties
    
    public ICollection<User> Users { get; set; }
}