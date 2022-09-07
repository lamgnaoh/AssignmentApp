using AssignmentApp.Data.Configurations;
using AssignmentApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AssignmentApp.Data.EF;

public class AssignmentAppDbContext: DbContext
{
    public AssignmentAppDbContext(DbContextOptions options) : base(options)
    {
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
    //         .AddJsonFile("appsettings.json").Build();
    //     var connectionString = configuration.GetConnectionString("AssignmentAppDatabase");
    //     optionsBuilder.UseSqlServer(connectionString);
    //     
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // add config cua cac entity o day
        modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
        modelBuilder.ApplyConfiguration(new AssignmentConfiguration());
        modelBuilder.ApplyConfiguration(new ClassConfiguration());
        modelBuilder.ApplyConfiguration(new StudentAssignmentConfiguration());
        modelBuilder.ApplyConfiguration(new UserClassConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<AppRole> AppRoles { get; set; }
    public DbSet<StudentAssignment> StudentAssignments { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserClass> UserClasses { get; set; }

}