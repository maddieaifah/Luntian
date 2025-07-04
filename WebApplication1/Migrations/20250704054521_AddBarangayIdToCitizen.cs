using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddBarangayIdToCitizen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BarangayId",
                table: "Citizens",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Citizens",
                keyColumn: "CitizenId",
                keyValue: 1,
                column: "BarangayId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Citizens_BarangayId",
                table: "Citizens",
                column: "BarangayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Citizens_Barangays_BarangayId",
                table: "Citizens",
                column: "BarangayId",
                principalTable: "Barangays",
                principalColumn: "BarangayId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citizens_Barangays_BarangayId",
                table: "Citizens");

            migrationBuilder.DropIndex(
                name: "IX_Citizens_BarangayId",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "BarangayId",
                table: "Citizens");
        }
    }
}
