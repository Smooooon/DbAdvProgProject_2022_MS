using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusterAG.DataAccessLayer.Migrations
{
    public partial class Beziehungen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Orders_OrderDaoId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_OrderDaoId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_ArticleGroups_HigherLevelArticleGroupId",
                table: "ArticleGroups");

            migrationBuilder.DropColumn(
                name: "OrderDaoId",
                table: "Positions");

            migrationBuilder.UpdateData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "HigherLevelArticleGroupId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 4,
                column: "HigherLevelArticleGroupId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 5,
                column: "HigherLevelArticleGroupId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 7,
                column: "HigherLevelArticleGroupId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 8,
                column: "HigherLevelArticleGroupId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 10,
                column: "HigherLevelArticleGroupId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_ArticleId",
                table: "Positions",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_OrderId",
                table: "Positions",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleGroups_HigherLevelArticleGroupId",
                table: "ArticleGroups",
                column: "HigherLevelArticleGroupId",
                unique: true,
                filter: "[HigherLevelArticleGroupId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_TownId",
                table: "Addresses",
                column: "TownId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Towns_TownId",
                table: "Addresses",
                column: "TownId",
                principalTable: "Towns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Articles_ArticleId",
                table: "Positions",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Orders_OrderId",
                table: "Positions",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Towns_TownId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Articles_ArticleId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Orders_OrderId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_ArticleId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_OrderId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_ArticleGroups_HigherLevelArticleGroupId",
                table: "ArticleGroups");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_TownId",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "OrderDaoId",
                table: "Positions",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "HigherLevelArticleGroupId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 4,
                column: "HigherLevelArticleGroupId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 5,
                column: "HigherLevelArticleGroupId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 7,
                column: "HigherLevelArticleGroupId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 8,
                column: "HigherLevelArticleGroupId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 10,
                column: "HigherLevelArticleGroupId",
                value: 9);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_OrderDaoId",
                table: "Positions",
                column: "OrderDaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleGroups_HigherLevelArticleGroupId",
                table: "ArticleGroups",
                column: "HigherLevelArticleGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Orders_OrderDaoId",
                table: "Positions",
                column: "OrderDaoId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
