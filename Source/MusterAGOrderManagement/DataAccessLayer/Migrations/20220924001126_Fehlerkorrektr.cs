using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusterAG.DataAccessLayer.Migrations
{
    public partial class Fehlerkorrektr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CustomerNr",
                value: "CU11111");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CustomerNr",
                value: "CU22222");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CustomerNr",
                value: "Cu11111");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CustomerNr",
                value: "Cu22222");
        }
    }
}
