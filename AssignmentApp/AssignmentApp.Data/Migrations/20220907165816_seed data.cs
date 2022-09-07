using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssignmentApp.Data.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "AssignmentId",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2022, 9, 7, 23, 58, 16, 518, DateTimeKind.Local).AddTicks(1821));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "AssignmentId",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2022, 9, 7, 23, 58, 16, 518, DateTimeKind.Local).AddTicks(1903));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "AssignmentId",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2022, 9, 7, 23, 53, 9, 126, DateTimeKind.Local).AddTicks(6960));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "AssignmentId",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2022, 9, 7, 23, 53, 9, 126, DateTimeKind.Local).AddTicks(7043));
        }
    }
}
