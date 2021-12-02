using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dash.Data.Migrations
{
    public partial class UniqueIndexCwYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WorkWeeks_CalendarWeek_Year",
                table: "WorkWeeks",
                columns: new[] { "CalendarWeek", "Year" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WorkWeeks_CalendarWeek_Year",
                table: "WorkWeeks");
        }
    }
}
