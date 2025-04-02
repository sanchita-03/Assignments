using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketBookingSystemApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserandBookingDataseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "9876543210", "John Doe" },
                    { 2, "jane.smith@example.com", "9876543211", "Jane Smith" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "BookingDate", "EventId", "SeatNumber", "Status", "UserId" },
                values: new object[] { 1, new DateTime(2025, 3, 28, 22, 8, 29, 823, DateTimeKind.Local).AddTicks(6091), 1, 1, "Pending", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
