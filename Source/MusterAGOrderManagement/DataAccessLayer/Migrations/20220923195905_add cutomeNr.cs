using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusterAG.DataAccessLayer.Migrations
{
    public partial class addcutomeNr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerNr",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerNr",
                table: "Customers")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "CustomersHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null);
        }
    }
}
