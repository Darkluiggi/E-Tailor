using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Tailor.Migrations
{
    public partial class removedtasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Tickets_Ticketid",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_Ticketid",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Ticketid",
                table: "Tasks");

            migrationBuilder.AddColumn<string>(
                name: "tasksIds",
                table: "Tickets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tasksIds",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "Ticketid",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_Ticketid",
                table: "Tasks",
                column: "Ticketid");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Tickets_Ticketid",
                table: "Tasks",
                column: "Ticketid",
                principalTable: "Tickets",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
