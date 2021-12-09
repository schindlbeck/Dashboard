using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dash.Data.Migrations
{
    public partial class Priotization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrioWeeks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalendarWeek = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    ProductionMinutes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrioWeeks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriotizedOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionCW = table.Column<int>(type: "int", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeTotal = table.Column<int>(type: "int", nullable: false),
                    PriorityWeekId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriotizedOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriotizedOrders_PrioWeeks_PriorityWeekId",
                        column: x => x.PriorityWeekId,
                        principalTable: "PrioWeeks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PriotizedOrders_PriorityWeekId",
                table: "PriotizedOrders",
                column: "PriorityWeekId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriotizedOrders");

            migrationBuilder.DropTable(
                name: "PrioWeeks");
        }
    }
}
