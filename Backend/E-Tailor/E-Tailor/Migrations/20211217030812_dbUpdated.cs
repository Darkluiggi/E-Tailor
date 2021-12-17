using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Tailor.Migrations
{
    public partial class dbUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apointments_Costumers_Costumerid",
                table: "Apointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Costumers_Costumerid",
                table: "Clothes");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_Costumerid",
                table: "Clothes");

            migrationBuilder.DropIndex(
                name: "IX_Apointments_Costumerid",
                table: "Apointments");

            migrationBuilder.DropColumn(
                name: "Costumerid",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "Costumerid",
                table: "Apointments");

            migrationBuilder.AddColumn<int>(
                name: "Customerid",
                table: "Clothes",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "name",
                table: "Clothes",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<int>(
                name: "Customerid",
                table: "Apointments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estado = table.Column<bool>(nullable: false),
                    idTailor = table.Column<int>(nullable: false),
                    idCustomer = table.Column<int>(nullable: false),
                    deliveryDate = table.Column<DateTime>(nullable: false),
                    servicePrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tickets_Costumers_idCustomer",
                        column: x => x.idCustomer,
                        principalTable: "Costumers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Tailors_idTailor",
                        column: x => x.idTailor,
                        principalTable: "Tailors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estado = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    price = table.Column<int>(nullable: false),
                    Ticketid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.id);
                    table.ForeignKey(
                        name: "FK_Task_Tickets_Ticketid",
                        column: x => x.Ticketid,
                        principalTable: "Tickets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_Customerid",
                table: "Clothes",
                column: "Customerid");

            migrationBuilder.CreateIndex(
                name: "IX_Apointments_Customerid",
                table: "Apointments",
                column: "Customerid");

            migrationBuilder.CreateIndex(
                name: "IX_Task_Ticketid",
                table: "Task",
                column: "Ticketid");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_idCustomer",
                table: "Tickets",
                column: "idCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_idTailor",
                table: "Tickets",
                column: "idTailor");

            migrationBuilder.AddForeignKey(
                name: "FK_Apointments_Costumers_Customerid",
                table: "Apointments",
                column: "Customerid",
                principalTable: "Costumers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Costumers_Customerid",
                table: "Clothes",
                column: "Customerid",
                principalTable: "Costumers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apointments_Costumers_Customerid",
                table: "Apointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Costumers_Customerid",
                table: "Clothes");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_Customerid",
                table: "Clothes");

            migrationBuilder.DropIndex(
                name: "IX_Apointments_Customerid",
                table: "Apointments");

            migrationBuilder.DropColumn(
                name: "Customerid",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "Customerid",
                table: "Apointments");

            migrationBuilder.AddColumn<int>(
                name: "Costumerid",
                table: "Clothes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Costumerid",
                table: "Apointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_Costumerid",
                table: "Clothes",
                column: "Costumerid");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Costumers_Costumerid",
                table: "Clothes",
                column: "Costumerid",
                principalTable: "Costumers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
