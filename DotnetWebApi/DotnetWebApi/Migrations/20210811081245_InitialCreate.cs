using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotnetWebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTasks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedEmployeeID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTasks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmployeeTasks_Employees_AssignedEmployeeID",
                        column: x => x.AssignedEmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "CreatedAt", "Department", "Designation", "Name" },
                values: new object[] { 1, new DateTime(2021, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Team", "Full Stack Developer", "Ashok" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "CreatedAt", "Department", "Designation", "Name" },
                values: new object[] { 2, new DateTime(2021, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Design Team", "UI/UX Designer", "Jim Doe" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTasks_AssignedEmployeeID",
                table: "EmployeeTasks",
                column: "AssignedEmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTasks");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
