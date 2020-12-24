using Microsoft.EntityFrameworkCore.Migrations;

namespace SpiritIslandLogger.Web.Data.Migrations
{
    public partial class UpdateDbContextforadversarylevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdversaryLevel_Adversaries_AdversaryId",
                table: "AdversaryLevel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdversaryLevel",
                table: "AdversaryLevel");

            migrationBuilder.RenameTable(
                name: "AdversaryLevel",
                newName: "AdversaryLevels");

            migrationBuilder.RenameIndex(
                name: "IX_AdversaryLevel_AdversaryId",
                table: "AdversaryLevels",
                newName: "IX_AdversaryLevels_AdversaryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdversaryLevels",
                table: "AdversaryLevels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdversaryLevels_Adversaries_AdversaryId",
                table: "AdversaryLevels",
                column: "AdversaryId",
                principalTable: "Adversaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdversaryLevels_Adversaries_AdversaryId",
                table: "AdversaryLevels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdversaryLevels",
                table: "AdversaryLevels");

            migrationBuilder.RenameTable(
                name: "AdversaryLevels",
                newName: "AdversaryLevel");

            migrationBuilder.RenameIndex(
                name: "IX_AdversaryLevels_AdversaryId",
                table: "AdversaryLevel",
                newName: "IX_AdversaryLevel_AdversaryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdversaryLevel",
                table: "AdversaryLevel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdversaryLevel_Adversaries_AdversaryId",
                table: "AdversaryLevel",
                column: "AdversaryId",
                principalTable: "Adversaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
