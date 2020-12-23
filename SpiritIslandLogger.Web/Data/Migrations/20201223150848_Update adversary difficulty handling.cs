using Microsoft.EntityFrameworkCore.Migrations;

namespace SpiritIslandLogger.Web.Data.Migrations
{
    public partial class Updateadversarydifficultyhandling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level0Difficulty",
                table: "Adversaries");

            migrationBuilder.DropColumn(
                name: "Level1Difficulty",
                table: "Adversaries");

            migrationBuilder.DropColumn(
                name: "Level2Difficulty",
                table: "Adversaries");

            migrationBuilder.DropColumn(
                name: "Level3Difficulty",
                table: "Adversaries");

            migrationBuilder.DropColumn(
                name: "Level4Difficulty",
                table: "Adversaries");

            migrationBuilder.DropColumn(
                name: "Level5Difficulty",
                table: "Adversaries");

            migrationBuilder.DropColumn(
                name: "Level6Difficulty",
                table: "Adversaries");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Adversaries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MappedDifficulty",
                table: "Adversaries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MappedDifficulty",
                table: "Adversaries");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Adversaries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Level0Difficulty",
                table: "Adversaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Level1Difficulty",
                table: "Adversaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Level2Difficulty",
                table: "Adversaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Level3Difficulty",
                table: "Adversaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Level4Difficulty",
                table: "Adversaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Level5Difficulty",
                table: "Adversaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Level6Difficulty",
                table: "Adversaries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
