using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class RebuildInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "VolunteerEvents");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "AutoTags",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "GeoPoint",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Hazard",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "IsBlurry",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "IsNSFW",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Barangays");

            migrationBuilder.DropColumn(
                name: "GeoBoundary",
                table: "Barangays");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VolunteerEvents",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "SubmittedAt",
                table: "Reports",
                newName: "SubmittedDate");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "Reports",
                newName: "PriorityLevel");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Reports",
                newName: "HazardLevel");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reports",
                newName: "ReportId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Barangays",
                newName: "BarangayName");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "VolunteerEvents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "VolunteerEvents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "VolunteerEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Point>(
                name: "LocationGeom",
                table: "VolunteerEvents",
                type: "geometry",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationText",
                table: "VolunteerEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OfficialId",
                table: "VolunteerEvents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Point>(
                name: "LocationGeom",
                table: "Reports",
                type: "geometry",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "LocationText",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "Barangays",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Barangays",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullAddress",
                table: "Barangays",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Polygon>(
                name: "Geom",
                table: "Barangays",
                type: "geometry",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubLocality",
                table: "Barangays",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Citizens",
                columns: table => new
                {
                    CitizenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizens", x => x.CitizenId);
                    table.ForeignKey(
                        name: "FK_Citizens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Officials",
                columns: table => new
                {
                    OfficialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BarangayId = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Officials", x => x.OfficialId);
                    table.ForeignKey(
                        name: "FK_Officials_Barangays_BarangayId",
                        column: x => x.BarangayId,
                        principalTable: "Barangays",
                        principalColumn: "BarangayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Officials_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CitizenId = table.Column<int>(type: "int", nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notifications_Citizens_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "Citizens",
                        principalColumn: "CitizenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId");
                    table.ForeignKey(
                        name: "FK_Notifications_VolunteerEvents_EventId",
                        column: x => x.EventId,
                        principalTable: "VolunteerEvents",
                        principalColumn: "EventId");
                });

            migrationBuilder.CreateTable(
                name: "ReportHistories",
                columns: table => new
                {
                    HistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    OfficialId = table.Column<int>(type: "int", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OldStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionTaken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportHistories", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_ReportHistories_Officials_OfficialId",
                        column: x => x.OfficialId,
                        principalTable: "Officials",
                        principalColumn: "OfficialId");
                    table.ForeignKey(
                        name: "FK_ReportHistories_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerEvents_OfficialId",
                table: "VolunteerEvents",
                column: "OfficialId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_CitizenId",
                table: "Reports",
                column: "CitizenId");

            migrationBuilder.CreateIndex(
                name: "IX_Citizens_UserId",
                table: "Citizens",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CitizenId",
                table: "Notifications",
                column: "CitizenId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_EventId",
                table: "Notifications",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ReportId",
                table: "Notifications",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Officials_BarangayId",
                table: "Officials",
                column: "BarangayId");

            migrationBuilder.CreateIndex(
                name: "IX_Officials_UserId",
                table: "Officials",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportHistories_OfficialId",
                table: "ReportHistories",
                column: "OfficialId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportHistories_ReportId",
                table: "ReportHistories",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Citizens_CitizenId",
                table: "Reports",
                column: "CitizenId",
                principalTable: "Citizens",
                principalColumn: "CitizenId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VolunteerEvents_Officials_OfficialId",
                table: "VolunteerEvents",
                column: "OfficialId",
                principalTable: "Officials",
                principalColumn: "OfficialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Citizens_CitizenId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_VolunteerEvents_Officials_OfficialId",
                table: "VolunteerEvents");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "ReportHistories");

            migrationBuilder.DropTable(
                name: "Citizens");

            migrationBuilder.DropTable(
                name: "Officials");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_VolunteerEvents_OfficialId",
                table: "VolunteerEvents");

            migrationBuilder.DropIndex(
                name: "IX_Reports_CitizenId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "VolunteerEvents");

            migrationBuilder.DropColumn(
                name: "LocationGeom",
                table: "VolunteerEvents");

            migrationBuilder.DropColumn(
                name: "LocationText",
                table: "VolunteerEvents");

            migrationBuilder.DropColumn(
                name: "OfficialId",
                table: "VolunteerEvents");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "LocationGeom",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "LocationText",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Barangays");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Barangays");

            migrationBuilder.DropColumn(
                name: "FullAddress",
                table: "Barangays");

            migrationBuilder.DropColumn(
                name: "Geom",
                table: "Barangays");

            migrationBuilder.DropColumn(
                name: "SubLocality",
                table: "Barangays");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "VolunteerEvents",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SubmittedDate",
                table: "Reports",
                newName: "SubmittedAt");

            migrationBuilder.RenameColumn(
                name: "PriorityLevel",
                table: "Reports",
                newName: "Priority");

            migrationBuilder.RenameColumn(
                name: "HazardLevel",
                table: "Reports",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "ReportId",
                table: "Reports",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BarangayName",
                table: "Barangays",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "VolunteerEvents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "VolunteerEvents",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "VolunteerEvents",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AutoTags",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Point>(
                name: "GeoPoint",
                table: "Reports",
                type: "geography",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hazard",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsBlurry",
                table: "Reports",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNSFW",
                table: "Reports",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Reports",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Reports",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Barangays",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<MultiPolygon>(
                name: "GeoBoundary",
                table: "Barangays",
                type: "geography",
                nullable: false);
        }
    }
}
