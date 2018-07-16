using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpdeskApp.Migrations
{
    public partial class AddLastname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Items",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Items");
        }
    }
}
