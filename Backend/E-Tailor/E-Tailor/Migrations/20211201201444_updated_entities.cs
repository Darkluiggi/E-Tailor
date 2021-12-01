using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Tailor.Migrations
{
    public partial class updated_entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "estado",
                table: "Tailors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "estado",
                table: "Registries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "estado",
                table: "Managers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "estado",
                table: "Costumers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "estado",
                table: "Clothes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "estado",
                table: "Apointments",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estado",
                table: "Tailors");

            migrationBuilder.DropColumn(
                name: "estado",
                table: "Registries");

            migrationBuilder.DropColumn(
                name: "estado",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "estado",
                table: "Costumers");

            migrationBuilder.DropColumn(
                name: "estado",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "estado",
                table: "Apointments");
        }
    }
}
