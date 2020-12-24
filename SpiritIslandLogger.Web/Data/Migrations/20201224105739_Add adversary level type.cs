using Microsoft.EntityFrameworkCore.Migrations;

namespace SpiritIslandLogger.Web.Data.Migrations
{
    public partial class Addadversaryleveltype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MappedDifficulty",
                table: "Adversaries");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvaderCardsLeft",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdversaryLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdversaryId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    DeckSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdversaryLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdversaryLevel_Adversaries_AdversaryId",
                        column: x => x.AdversaryId,
                        principalTable: "Adversaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdversaryLevel_AdversaryId",
                table: "AdversaryLevel",
                column: "AdversaryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdversaryLevel");

            migrationBuilder.DropColumn(
                name: "InvaderCardsLeft",
                table: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "MappedDifficulty",
                table: "Adversaries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
