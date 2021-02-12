using Microsoft.EntityFrameworkCore.Migrations;

namespace SpiritIslandLogger.Web.Data.Migrations
{
    public partial class Storescoreinthegametable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Games",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "Games");
        }
    }
}
