using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: true),
                    Biography = table.Column<string>(type: "text", nullable: true),
                    ELO = table.Column<int>(type: "integer", nullable: false),
                    Privilege = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WhiteUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    BlackUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    WhiteELO = table.Column<int>(type: "integer", nullable: false),
                    BlackELO = table.Column<int>(type: "integer", nullable: false),
                    WhiteRatingDiff = table.Column<int>(type: "integer", nullable: false),
                    BlackRatingDiff = table.Column<int>(type: "integer", nullable: false),
                    Result = table.Column<string>(type: "text", nullable: false),
                    GameMoves = table.Column<string>(type: "text", nullable: false),
                    TimeControl = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    StartGameTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndGameTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Users_BlackUserId",
                        column: x => x.BlackUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_Users_WhiteUserId",
                        column: x => x.WhiteUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_BlackUserId",
                table: "Games",
                column: "BlackUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_WhiteUserId",
                table: "Games",
                column: "WhiteUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
