using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusterAG.DataAccessLayer.Migrations
{
    public partial class Testdaten : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "ArticleGroups",
                columns: new[] { "Id", "HigherLevelArticleGroupId", "Name" },
                values: new object[] { 1, null, "Lebensmittel" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "Ordered" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 3, 2, 15, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2022, 3, 1, 12, 5, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, new DateTime(2022, 2, 27, 8, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "ArticleId", "OrderDaoId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, null, 1, 2 },
                    { 2, 4, null, 1, 1 },
                    { 3, 3, null, 2, 2 },
                    { 4, 5, null, 2, 6 },
                    { 5, 2, null, 3, 1 },
                    { 6, 5, null, 3, 6 }
                });

            migrationBuilder.InsertData(
                table: "ArticleGroups",
                columns: new[] { "Id", "HigherLevelArticleGroupId", "Name" },
                values: new object[] { 2, 1, "Getränke" });

            migrationBuilder.InsertData(
                table: "ArticleGroups",
                columns: new[] { "Id", "HigherLevelArticleGroupId", "Name" },
                values: new object[,]
                {
                    { 3, 2, "Alkohol" },
                    { 4, 2, "Non-Alkohol" },
                    { 7, 2, "Fleisch" },
                    { 8, 2, "Obst" },
                    { 9, 2, "Getreide" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleGroupId", "Name", "Price" },
                values: new object[] { 5, 2, "Sinalco", 3.40m });

            migrationBuilder.InsertData(
                table: "ArticleGroups",
                columns: new[] { "Id", "HigherLevelArticleGroupId", "Name" },
                values: new object[,]
                {
                    { 5, 3, "Likör" },
                    { 6, 3, "Kreuterschnaps" },
                    { 10, 9, "Teigwaren" },
                    { 11, 9, "Brot" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleGroupId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 9, "Vollkornbrot", 4.20m },
                    { 2, 9, "Zopf", 5.80m },
                    { 3, 3, "Appenzeller", 34.00m },
                    { 4, 3, "Eierlikör", 8.70m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleGroupId",
                table: "Articles",
                column: "ArticleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleGroups_HigherLevelArticleGroupId",
                table: "ArticleGroups",
                column: "HigherLevelArticleGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleGroups_ArticleGroups_HigherLevelArticleGroupId",
                table: "ArticleGroups",
                column: "HigherLevelArticleGroupId",
                principalTable: "ArticleGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_ArticleGroups_ArticleGroupId",
                table: "Articles",
                column: "ArticleGroupId",
                principalTable: "ArticleGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleGroups_ArticleGroups_HigherLevelArticleGroupId",
                table: "ArticleGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_ArticleGroups_ArticleGroupId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ArticleGroupId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_ArticleGroups_HigherLevelArticleGroupId",
                table: "ArticleGroups");

            migrationBuilder.DeleteData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Positions");

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
