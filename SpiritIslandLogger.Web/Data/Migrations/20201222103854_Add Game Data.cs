using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpiritIslandLogger.Web.Data.Migrations
{
    public partial class AddGameData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adversaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level0Difficulty = table.Column<int>(type: "int", nullable: false),
                    Level1Difficulty = table.Column<int>(type: "int", nullable: false),
                    Level2Difficulty = table.Column<int>(type: "int", nullable: false),
                    Level3Difficulty = table.Column<int>(type: "int", nullable: false),
                    Level4Difficulty = table.Column<int>(type: "int", nullable: false),
                    Level5Difficulty = table.Column<int>(type: "int", nullable: false),
                    Level6Difficulty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adversaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spirits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spirits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Victory = table.Column<bool>(type: "bit", nullable: false),
                    AdversaryId = table.Column<int>(type: "int", nullable: true),
                    AdversaryLevel = table.Column<int>(type: "int", nullable: true),
                    ManualScore = table.Column<int>(type: "int", nullable: true),
                    DahanLeft = table.Column<int>(type: "int", nullable: true),
                    BlightCount = table.Column<int>(type: "int", nullable: true),
                    BlightedIsland = table.Column<bool>(type: "bit", nullable: true),
                    FearLevel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Adversaries_AdversaryId",
                        column: x => x.AdversaryId,
                        principalTable: "Adversaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GamePlayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: true),
                    SpiritId = table.Column<int>(type: "int", nullable: true),
                    GameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamePlayers_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GamePlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GamePlayers_Spirits_SpiritId",
                        column: x => x.SpiritId,
                        principalTable: "Spirits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayers_GameId",
                table: "GamePlayers",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayers_PlayerId",
                table: "GamePlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayers_SpiritId",
                table: "GamePlayers",
                column: "SpiritId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_AdversaryId",
                table: "Games",
                column: "AdversaryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamePlayers");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Spirits");

            migrationBuilder.DropTable(
                name: "Adversaries");
        }
    }
}
