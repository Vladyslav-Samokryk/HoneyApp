using Microsoft.EntityFrameworkCore.Migrations;

namespace HoneyDataBace.Migrations
{
    public partial class RenameCulomns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Priсe",
                table: "Honeys",
                newName: "Price");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Honeys",
                newName: "Priсe");
        }
    }
}
