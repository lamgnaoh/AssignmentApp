using AssignmentApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssignmentApp.Data.Configurations;

public class UserRoleConfiguration:IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRoles");
        builder.HasKey(x => new { x.RoleId, x.UserId });
        //user quan he nhieu-nhieu voi AppRole
        builder.HasOne(x => x.User).WithMany(x => x.UserRoles).HasForeignKey(x => x.UserId);
        builder.HasOne(x => x.AppRole).WithMany(x => x.UserRoles).HasForeignKey(x => x.RoleId);
    }
}