using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpdeskApp.Migrations
{
    public partial class AddSeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "FullName" },
                values: new object[,]
                {
                    { 1, "Brad Bobley" },
                    { 2, "Bob Bradley" },
                    { 3, "Chris Crosby" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Desktop support" },
                    { 2, "Helpdesk" },
                    { 3, "Application support" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "AssignmentGroupId", "ContactId", "Description" },
                values: new object[,]
                {
                    { 1, 1, 1, "NullaPede.mov" },
                    { 2, 1, 1, "NecNisiVolutpat.ppt" },
                    { 3, 1, 1, "JustoPellentesque.tiff" },
                    { 4, 2, 1, "LobortisSapienSapien.xls" },
                    { 5, 2, 2, "ConsequatVarius.mp3" },
                    { 6, 2, 2, "BibendumMorbi.xls" },
                    { 7, 2, 3, "Parturient.tiff" },
                    { 8, 3, 3, "AugueVestibulum.pdf" },
                    { 9, 3, 3, "NibhLigula.png" },
                    { 10, 3, 3, "IpsumPrimisIn.jpeg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
