﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssignmentApp.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PhoneNumber = table.Column<string>(type: "char(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    MSSV = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    FullName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
            migrationBuilder.Sql(
                "Alter table [Users] add constraint CK_Username check((Username = Fullname + ' ' + MSSV and MSSV is not null ) Or (Username = Fullname and MSSV is null))");
            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_Assignments_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.CheckConstraint("CK_DueTo_CreateAt", "Datediff(minute , CreateAt, DueTo) > 0");
                });

            migrationBuilder.CreateTable(
                name: "UserClasses",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClasses", x => new { x.UserId, x.ClassId });
                    table.ForeignKey(
                        name: "FK_UserClasses_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClasses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRoles_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAssignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Submitted = table.Column<bool>(type: "bit", nullable: false),
                    Grade = table.Column<double>(type: "float", nullable: true),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Feedback = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssignments", x => new { x.AssignmentId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentAssignments_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAssignments_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "RoleId", "role" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 1 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "Name" },
                values: new object[,]
                {
                    { 1, "project 20213" },
                    { 2, "Lap trinh .NET Core" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "MSSV", "Password", "PhoneNumber", "Username" },
                values: new object[,]
                {
                    { 1, "lam.lh183780@sis.hust.edu.vn", "Luong Hoang Lam", "20183780", "12345678", "0123123xxx", "Luong Hoang Lam 20183780" },
                    { 2, "lam.db183779@sis.hust.edu.vn", "Dang Bao Lam", "20183779", "12345678", "0456456xxx", "Dang Bao Lam 20183779" },
                    { 3, "thuan.nguyendinh@hust.edu.vn", "Nguyen Dinh Thuan", null, "12345678", "0789789xxx", "Nguyen Dinh Thuan" },
                    { 4, "admin@hust.edu.vn", "admin", null, "admin", "0456789xxx", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "AssignmentId", "ClassId", "Content", "CreateAt", "DueTo", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Nộp báo cáo tuần 1 ", new DateTime(2022, 9, 7, 23, 53, 9, 126, DateTimeKind.Local).AddTicks(6960), new DateTime(2022, 9, 8, 23, 30, 0, 0, DateTimeKind.Unspecified), "Báo cáo tuần 1" },
                    { 2, 2, "Lập trình .NET WEB API", new DateTime(2022, 9, 7, 23, 53, 9, 126, DateTimeKind.Local).AddTicks(7043), new DateTime(2022, 9, 9, 23, 30, 0, 0, DateTimeKind.Unspecified), ".NET WEB API" }
                });

            migrationBuilder.InsertData(
                table: "UserClasses",
                columns: new[] { "ClassId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 3 },
                    { 3, 1 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "StudentAssignments",
                columns: new[] { "AssignmentId", "StudentId", "Feedback", "Grade", "Submitted", "SubmittedAt" },
                values: new object[] { 1, 1, "Tốt", 10.0, true, new DateTime(2022, 9, 7, 23, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "StudentAssignments",
                columns: new[] { "AssignmentId", "StudentId", "Feedback", "Grade", "Submitted", "SubmittedAt" },
                values: new object[] { 1, 2, null, null, false, null });

            migrationBuilder.InsertData(
                table: "StudentAssignments",
                columns: new[] { "AssignmentId", "StudentId", "Feedback", "Grade", "Submitted", "SubmittedAt" },
                values: new object[] { 2, 1, null, null, true, new DateTime(2022, 9, 7, 23, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_ClassId",
                table: "Assignments",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignments_StudentId",
                table: "StudentAssignments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClasses_ClassId",
                table: "UserClasses",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAssignments");

            migrationBuilder.DropTable(
                name: "UserClasses");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}