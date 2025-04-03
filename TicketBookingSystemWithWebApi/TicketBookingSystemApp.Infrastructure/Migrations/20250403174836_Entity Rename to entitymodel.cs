using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketBookingSystemApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EntityRenametoentitymodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1,
                column: "BookingDate",
                value: new DateTime(2025, 4, 3, 17, 48, 35, 756, DateTimeKind.Utc).AddTicks(9997));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1,
                column: "BookingDate",
                value: new DateTime(2025, 4, 1, 7, 59, 36, 674, DateTimeKind.Utc).AddTicks(7662));
        }
    }
}
