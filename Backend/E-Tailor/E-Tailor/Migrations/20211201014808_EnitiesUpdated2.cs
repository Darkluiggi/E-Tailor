using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Tailor.Migrations
{
    public partial class EnitiesUpdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Costumerid",
                table: "Apointments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apointments_Costumerid",
                table: "Apointments",
                column: "Costumerid");

            migrationBuilder.AddForeignKey(
                name: "FK_Apointments_Costumers_Costumerid",
                table: "Apointments",
                column: "Costumerid",
                principalTable: "Costumers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apointments_Costumers_Costumerid",
                table: "Apointments");

            migrationBuilder.DropIndex(
                name: "IX_Apointments_Costumerid",
                table: "Apointments");

            migrationBuilder.DropColumn(
                name: "Costumerid",
                table: "Apointments");
        }
    }
}
