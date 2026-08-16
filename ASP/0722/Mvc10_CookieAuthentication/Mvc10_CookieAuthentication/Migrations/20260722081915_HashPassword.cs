using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mvc10_CookieAuthentication.Migrations
{
    /// <inheritdoc />
    public partial class HashPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U001",
                column: "Password",
                value: "827ccb0eea8a706c4c34a16891f84e7b");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U002",
                column: "Password",
                value: "827ccb0eea8a706c4c34a16891f84e7b");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U003",
                column: "Password",
                value: "827ccb0eea8a706c4c34a16891f84e7b");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U001",
                column: "Password",
                value: "12345");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U002",
                column: "Password",
                value: "12345");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "U003",
                column: "Password",
                value: "12345");
        }
    }
}
