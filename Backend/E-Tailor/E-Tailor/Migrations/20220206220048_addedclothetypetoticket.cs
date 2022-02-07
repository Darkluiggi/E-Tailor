using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Tailor.Migrations
{
    public partial class addedclothetypetoticket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "clotheType",
                table: "Tickets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "clotheType",
                table: "Tickets");
        }
    }
}
