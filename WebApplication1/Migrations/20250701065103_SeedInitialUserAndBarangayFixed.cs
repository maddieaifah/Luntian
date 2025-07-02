using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialUserAndBarangayFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Barangays",
                columns: new[] { "BarangayId", "BarangayName", "ContactNumber", "Email", "FullAddress", "Geom", "SubLocality" },
                values: new object[] { 1, "Barangay 630", "09123456789", "barangay630@manila.gov.ph", "Sta. Mesa, Manila", null, "Sta. Mesa" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Email", "LastLogin", "PasswordHash", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "citizen@example.com", null, "citizen123", "Citizen" },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "official@example.com", null, "official123", "Official" }
                });

            migrationBuilder.InsertData(
                table: "Citizens",
                columns: new[] { "CitizenId", "Address", "Age", "FirstName", "LastName", "ProfilePictureUrl", "Sex", "UserId" },
                values: new object[] { 1, "Sample Street, Manila", 25, "Juan", "Dela Cruz", null, "Male", 1 });

            migrationBuilder.InsertData(
                table: "Officials",
                columns: new[] { "OfficialId", "BarangayId", "ContactNumber", "FirstName", "LastName", "Position", "UserId" },
                values: new object[] { 1, 1, "09999999999", "Maria", "Santos", "Barangay Captain", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Citizens",
                keyColumn: "CitizenId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Officials",
                keyColumn: "OfficialId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Barangays",
                keyColumn: "BarangayId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);
        }
    }
}
