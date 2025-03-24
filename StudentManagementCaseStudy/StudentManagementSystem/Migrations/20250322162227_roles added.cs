using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagementSystem.Migrations
{
    public partial class rolesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88ab04a3-c435-4ee7-8c75-bbf66fc8f38d", "a5827f23-0c78-45af-b792-5936b4bf4758", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88ab04a4-c435-4ee7-8c75-bbf66cd8f38d", "5f4d0620-17d4-4bba-9a40-1c86bf065d17", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88ab04a5-c435-4ee7-8c75-bbf66cd8f38d", "ed5307c5-9ddd-4e80-ab2f-021feed5813a", "Teacher", "TEACHER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88ab04a3-c435-4ee7-8c75-bbf66fc8f38d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88ab04a4-c435-4ee7-8c75-bbf66cd8f38d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88ab04a5-c435-4ee7-8c75-bbf66cd8f38d");
        }
    }
}
