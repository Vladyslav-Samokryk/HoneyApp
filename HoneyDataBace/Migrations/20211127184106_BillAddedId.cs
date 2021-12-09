using Microsoft.EntityFrameworkCore.Migrations;

namespace HoneyDataBace.Migrations
{
    public partial class BillAddedId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BillItems",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillItems",
                table: "BillItems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BillItems_BillId",
                table: "BillItems",
                column: "BillId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillItems_Bills_BillId",
                table: "BillItems",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillItems_Bills_BillId",
                table: "BillItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillItems",
                table: "BillItems");

            migrationBuilder.DropIndex(
                name: "IX_BillItems_BillId",
                table: "BillItems");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BillItems");
        }
    }
}
