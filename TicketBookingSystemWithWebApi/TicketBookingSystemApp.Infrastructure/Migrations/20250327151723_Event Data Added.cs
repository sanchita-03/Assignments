using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketBookingSystemApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EventDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "AvailableSeats", "Date", "Description", "EventName", "EventType", "Price", "Venue" },
                values: new object[,]
                {
                    { 1, 500, new DateTime(2025, 6, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), "A premier technology conference featuring industry experts and innovations.", "Tech Conference 2025", "Conference", 2999m, "Convention Center, Mumbai" },
                    { 2, 1000, new DateTime(2025, 7, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), "A grand music festival featuring top artists.", "Music Fest 2025", "Concert", 1999m, "Stadium, Delhi" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2);
        }
    }
}
