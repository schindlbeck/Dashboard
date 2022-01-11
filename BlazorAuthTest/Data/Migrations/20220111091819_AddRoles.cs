using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAuthTest.Data.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6616815a-db29-48b2-92b7-72d8659d15a3", "2b9cb30c-a705-4caf-a5aa-1ba8543be97d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "73e97dca-4457-4f33-a056-bf4cdc2f74b4", "2cac87c3-1697-44cb-9859-f6fb8fa73de0", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6616815a-db29-48b2-92b7-72d8659d15a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73e97dca-4457-4f33-a056-bf4cdc2f74b4");
        }
    }
}
