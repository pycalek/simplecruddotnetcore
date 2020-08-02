using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleCrud.Migrations
{
    public partial class _2020July290010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeNumber = table.Column<int>(fixedLength: true, nullable: false),
                    FullName = table.Column<string>(maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    IDNumber = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeID", "Address", "DateOfBirth", "EmployeeNumber", "FullName", "IDNumber" },
                values: new object[] { 1, "Colombo Sri Lanka", new DateTime(1988, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 10000, "Ajith Ramawickrama", "234242312X" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeID", "Address", "DateOfBirth", "EmployeeNumber", "FullName", "IDNumber" },
                values: new object[] { 2, "New york, United States", new DateTime(1988, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 10000, "Perter Manuel", "234242312X" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
