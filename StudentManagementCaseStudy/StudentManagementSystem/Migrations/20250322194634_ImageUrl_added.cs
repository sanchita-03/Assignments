using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagementSystem.Migrations
{
    public partial class ImageUrl_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88ab04a3-c435-4ee7-8c75-bbf66fc8f38d",
                column: "ConcurrencyStamp",
                value: "9157ff5c-f10c-433f-a34e-ac3381d4af93");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88ab04a4-c435-4ee7-8c75-bbf66cd8f38d",
                column: "ConcurrencyStamp",
                value: "7423cbba-6110-4155-a087-16c6f0bbed26");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88ab04a5-c435-4ee7-8c75-bbf66cd8f38d",
                column: "ConcurrencyStamp",
                value: "92eb67c8-be34-4f99-973b-40c941b53924");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88ab04a3-c435-4ee7-8c75-bbf66fc8f38d",
                column: "ConcurrencyStamp",
                value: "2ebb0803-4ee8-43fe-aa48-8382c37be0b0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88ab04a4-c435-4ee7-8c75-bbf66cd8f38d",
                column: "ConcurrencyStamp",
                value: "e8bd7945-4bc8-4ecc-8049-bb080f293ec3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88ab04a5-c435-4ee7-8c75-bbf66cd8f38d",
                column: "ConcurrencyStamp",
                value: "403c6dee-75ce-4dbf-bf0f-afeab8935d77");
        }
    }
}
