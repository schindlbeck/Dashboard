using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dash.Data.Migrations
{
    public partial class Week : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CalendarWeek",
                table: "WorkDays",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalendarWeek",
                table: "WorkDays");
        }
    }
}
