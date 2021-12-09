using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dash.Data.Migrations
{
    public partial class PriorityweeksRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriotizedOrders_PrioWeeks_PriorityWeekId",
                table: "PriotizedOrders");

            migrationBuilder.DropTable(
                name: "PrioWeeks");

            migrationBuilder.DropIndex(
                name: "IX_PriotizedOrders_PriorityWeekId",
                table: "PriotizedOrders");

            migrationBuilder.DropColumn(
                name: "PriorityWeekId",
                table: "PriotizedOrders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriorityWeekId",
                table: "PriotizedOrders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PrioWeeks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalendarWeek = table.Column<int>(type: "int", nullable: false),
                    ProductionMinutes = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrioWeeks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PriotizedOrders_PriorityWeekId",
                table: "PriotizedOrders",
                column: "PriorityWeekId");

            migrationBuilder.AddForeignKey(
                name: "FK_PriotizedOrders_PrioWeeks_PriorityWeekId",
                table: "PriotizedOrders",
                column: "PriorityWeekId",
                principalTable: "PrioWeeks",
                principalColumn: "Id");
        }
    }
}
