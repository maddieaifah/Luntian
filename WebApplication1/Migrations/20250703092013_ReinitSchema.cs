using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class ReinitSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add column only if not already in DB manually
            migrationBuilder.AddColumn<string>(
                name: "BarangayMasterPCode",
                table: "Barangays",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            // Create index
            migrationBuilder.CreateIndex(
                name: "IX_Barangays_BarangayMasterPCode",
                table: "Barangays",
                column: "BarangayMasterPCode");

            // Add FK to BarangayMasters.ADM4_PCODE
            migrationBuilder.AddForeignKey(
                name: "FK_Barangays_BarangayMasters_BarangayMasterPCode",
                table: "Barangays",
                column: "BarangayMasterPCode",
                principalTable: "BarangayMasters",
                principalColumn: "ADM4_PCODE",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Safely remove FK and column only
            migrationBuilder.DropForeignKey(
                name: "FK_Barangays_BarangayMasters_BarangayMasterPCode",
                table: "Barangays");

            migrationBuilder.DropIndex(
                name: "IX_Barangays_BarangayMasterPCode",
                table: "Barangays");

            migrationBuilder.DropColumn(
                name: "BarangayMasterPCode",
                table: "Barangays");

            // Remove seeded rows (optional if you're rolling back)
            migrationBuilder.DeleteData("Officials", "OfficialId", 1);
            migrationBuilder.DeleteData("Citizens", "CitizenId", 1);
            migrationBuilder.DeleteData("Users", "UserId", 1);
            migrationBuilder.DeleteData("Users", "UserId", 2);
            migrationBuilder.DeleteData("Barangays", "BarangayId", 1);
        }
    }
}
