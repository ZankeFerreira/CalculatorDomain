using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Calculation",
                columns: new[] { "Id", "CreatedAt", "Left", "Operation", "Result", "Right" },
                values: new object[] { 2, new DateTime(2026, 2, 10, 10, 9, 18, 553, DateTimeKind.Utc).AddTicks(6210), 2.0, 0, 5.0, 5.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Calculation",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
