using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Tailor.Migrations
{
    public partial class clothUpdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Costumers_Customerid",
                table: "Clothes");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_Customerid",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "Customerid",
                table: "Clothes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Customerid",
                table: "Clothes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_Customerid",
                table: "Clothes",
                column: "Customerid");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Costumers_Customerid",
                table: "Clothes",
                column: "Customerid",
                principalTable: "Costumers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
