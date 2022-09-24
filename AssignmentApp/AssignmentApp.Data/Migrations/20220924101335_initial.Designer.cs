﻿// <auto-generated />
using System;
using AssignmentApp.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AssignmentApp.Data.Migrations
{
    [DbContext(typeof(AssignmentAppDbContext))]
    [Migration("20220924101335_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AssignmentApp.Data.Entities.AppRole", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("AppRoles", (string)null);

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            Name = "admin"
                        },
                        new
                        {
                            RoleId = 2,
                            Name = "teacher"
                        },
                        new
                        {
                            RoleId = 3,
                            Name = "student"
                        });
                });

            modelBuilder.Entity("AssignmentApp.Data.Entities.Assignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentId"), 1L, 1);

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AssignmentId");

                    b.HasIndex("ClassId");

                    b.ToTable("Assignments", (string)null);

                    b.HasData(
                        new
                        {
                            AssignmentId = 1,
                            ClassId = 1,
                            Content = "Nộp báo cáo tuần 1 ",
                            CreateAt = new DateTime(2022, 9, 6, 23, 30, 0, 0, DateTimeKind.Unspecified),
                            DueTo = new DateTime(2022, 9, 8, 23, 30, 0, 0, DateTimeKind.Unspecified),
                            Title = "Báo cáo tuần 1"
                        },
                        new
                        {
                            AssignmentId = 2,
                            ClassId = 2,
                            Content = "Lập trình .NET WEB API",
                            CreateAt = new DateTime(2022, 9, 8, 23, 30, 0, 0, DateTimeKind.Unspecified),
                            DueTo = new DateTime(2022, 9, 9, 23, 30, 0, 0, DateTimeKind.Unspecified),
                            Title = ".NET WEB API"
                        });
                });

            modelBuilder.Entity("AssignmentApp.Data.Entities.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"), 1L, 1);

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ClassId");

                    b.ToTable("Classes", (string)null);

                    b.HasData(
                        new
                        {
                            ClassId = 1,
                            CreateAt = new DateTime(2022, 6, 8, 23, 30, 0, 0, DateTimeKind.Unspecified),
                            Name = "project 20213"
                        },
                        new
                        {
                            ClassId = 2,
                            CreateAt = new DateTime(2022, 5, 11, 15, 30, 0, 0, DateTimeKind.Unspecified),
                            Name = "Lap trinh .NET Core"
                        });
                });

            modelBuilder.Entity("AssignmentApp.Data.Entities.StudentAssignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("Feedback")
                        .HasMaxLength(500)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(500)");

                    b.Property<double?>("Grade")
                        .HasColumnType("float");

                    b.Property<bool>("Submitted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("SubmittedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("AssignmentId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentAssignments", (string)null);

                    b.HasData(
                        new
                        {
                            AssignmentId = 1,
                            StudentId = 1,
                            Feedback = "Tốt",
                            Grade = 10.0,
                            Submitted = true,
                            SubmittedAt = new DateTime(2022, 9, 7, 23, 30, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AssignmentId = 1,
                            StudentId = 2,
                            Submitted = false
                        },
                        new
                        {
                            AssignmentId = 2,
                            StudentId = 1,
                            Submitted = true,
                            SubmittedAt = new DateTime(2022, 9, 7, 23, 30, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("AssignmentApp.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MSSV")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("char(15)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "lam.lh183780@sis.hust.edu.vn",
                            FullName = "Luong Hoang Lam",
                            MSSV = "20183780",
                            Password = "12345678",
                            PhoneNumber = "0123123xxx",
                            Username = "Luong Hoang Lam 20183780"
                        },
                        new
                        {
                            Id = 2,
                            Email = "lam.db183779@sis.hust.edu.vn",
                            FullName = "Dang Bao Lam",
                            MSSV = "20183779",
                            Password = "12345678",
                            PhoneNumber = "0456456xxx",
                            Username = "Dang Bao Lam 20183779"
                        },
                        new
                        {
                            Id = 3,
                            Email = "thuan.nguyendinh@hust.edu.vn",
                            FullName = "Nguyen Dinh Thuan",
                            Password = "12345678",
                            PhoneNumber = "0789789xxx",
                            Username = "Nguyen Dinh Thuan"
                        },
                        new
                        {
                            Id = 4,
                            Email = "admin@hust.edu.vn",
                            FullName = "admin",
                            Password = "admin",
                            PhoneNumber = "0456789xxx",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("AssignmentApp.Data.Entities.UserClass", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ClassId");

                    b.HasIndex("ClassId");

                    b.ToTable("UserClasses", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            ClassId = 1
                        },
                        new
                        {
                            UserId = 2,
                            ClassId = 1
                        },
                        new
                        {
                            UserId = 3,
                            ClassId = 1
                        },
                        new
                        {
                            UserId = 1,
                            ClassId = 2
                        },
                        new
                        {
                            UserId = 3,
                            ClassId = 2
                        });
                });

            modelBuilder.Entity("AssignmentApp.Data.Entities.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 3
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 3
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 4,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("AssignmentApp.Data.Entities.Assignment", b =>
                {
                    b.HasOne("AssignmentApp.Data.Entities.Class", "Class")
                        .WithMany("Assignments")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("AssignmentApp.Data.Entities.StudentAssignment", b =>
                {
                    b.HasOne("AssignmentApp.Data.Entities.Assignment", "Assignment")
                        .WithMany("StudentAssignments")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssignmentApp.Data.Entities.User", "User")
                        .WithMany("StudentAssignments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AssignmentApp.Data.Entities.UserClass", b =>
                {
                    b.HasOne("AssignmentApp.Data.Entities.Class", "Class")
                        .WithMany("UserClasses")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssignmentApp.Data.Entities.User", "User")
                        .WithMany("UserClasses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AssignmentApp.Data.Entities.UserRole", b =>
                {
                    b.HasOne("AssignmentApp.Data.Entities.AppRole", "AppRole")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssignmentApp.Data.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppRole");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AssignmentApp.Data.Entities.AppRole", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("AssignmentApp.Data.Entities.Assignment", b =>
                {
                    b.Navigation("StudentAssignments");
                });

            modelBuilder.Entity("AssignmentApp.Data.Entities.Class", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("UserClasses");
                });

            modelBuilder.Entity("AssignmentApp.Data.Entities.User", b =>
                {
                    b.Navigation("StudentAssignments");

                    b.Navigation("UserClasses");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
