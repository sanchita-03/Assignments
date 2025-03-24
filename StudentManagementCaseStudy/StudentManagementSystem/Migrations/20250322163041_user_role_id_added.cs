using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagementSystem.Migrations
{
    public partial class user_role_id_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "88ab04a3-c435-4ee7-8c75-bbf66fc8f38d", "4588227f-ec2c-4077-aeca-a7ca8df30b4b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "88ab04a3-c435-4ee7-8c75-bbf66fc8f38d", "4588227f-ec2c-4077-aeca-a7ca8df30b4b" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88ab04a3-c435-4ee7-8c75-bbf66fc8f38d",
                column: "ConcurrencyStamp",
                value: "a5827f23-0c78-45af-b792-5936b4bf4758");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88ab04a4-c435-4ee7-8c75-bbf66cd8f38d",
                column: "ConcurrencyStamp",
                value: "5f4d0620-17d4-4bba-9a40-1c86bf065d17");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88ab04a5-c435-4ee7-8c75-bbf66cd8f38d",
                column: "ConcurrencyStamp",
                value: "ed5307c5-9ddd-4e80-ab2f-021feed5813a");
        }
    }
}
