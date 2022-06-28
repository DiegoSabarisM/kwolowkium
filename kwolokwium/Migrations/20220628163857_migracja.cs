using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kwolokwium.Migrations
{
    public partial class migracja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrganizationDomain = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationID);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizaionID = table.Column<int>(type: "int", nullable: false),
                    MemberName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MemberSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MemberNickname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberID);
                    table.ForeignKey(
                        name: "FK_Members_Organizations_OrganizaionID",
                        column: x => x.OrganizaionID,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationID");
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizaionID = table.Column<int>(type: "int", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeamDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Teams_Organizations_OrganizaionID",
                        column: x => x.OrganizaionID,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationID");
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    FileID = table.Column<int>(type: "int", nullable: false),
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => new { x.FileID, x.TeamID });
                    table.ForeignKey(
                        name: "FK_Files_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID");
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    MembershipDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => new { x.MemberID, x.TeamID });
                    table.ForeignKey(
                        name: "FK_Memberships_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_Memberships_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID");
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "OrganizationID", "OrganizationDomain", "OrganizationName" },
                values: new object[] { 20, "IT", "ffff" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberID", "MemberName", "MemberNickname", "MemberSurname", "OrganizaionID" },
                values: new object[] { 11, "Nestor", null, "En bloque", 20 });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamID", "OrganizaionID", "TeamDescription", "TeamName" },
                values: new object[] { 22, 20, null, "losblocks" });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "FileID", "TeamID", "FileExtension", "FileName", "FileSize" },
                values: new object[] { 99, 22, "txt", "ufos-attack", 3000 });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "MemberID", "TeamID", "MembershipDate" },
                values: new object[] { 11, 22, new DateTime(2022, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Files_TeamID",
                table: "Files",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Members_OrganizaionID",
                table: "Members",
                column: "OrganizaionID");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_TeamID",
                table: "Memberships",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_OrganizaionID",
                table: "Teams",
                column: "OrganizaionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
