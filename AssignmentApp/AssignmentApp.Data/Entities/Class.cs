namespace AssignmentApp.Data.Entities;

public class Class
{
    public int ClassId { get; set; }
    public string Name { get; set; }
    
  // navigation property
    public ICollection<Assignment> Assignments { get; set; }
    public ICollection<UserClass> UserClasses { get; set; }
}