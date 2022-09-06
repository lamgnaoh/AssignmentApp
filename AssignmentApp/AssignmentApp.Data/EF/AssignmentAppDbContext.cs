using AssignmentApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AssignmentApp.Data.EF;

public class AssignmentAppDbContext: DbContext
{
    public AssignmentAppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<AppRole> AppRoles { get; set; }
    public DbSet<StudentAssignment> StudentAssignments { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserClass> UserClasses { get; set; }

}