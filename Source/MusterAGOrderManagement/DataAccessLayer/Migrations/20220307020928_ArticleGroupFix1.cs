using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusterAG.DataAccessLayer.Migrations
{
    public partial class ArticleGroupFix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ArticleGroups_HigherLevelArticleGroupId",
                table: "ArticleGroups");

            migrationBuilder.AddColumn<int>(
                name: "ArticleGroupDaoId",
                table: "ArticleGroups",
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
                name: "IX_ArticleGroups_ArticleGroupDaoId",
                table: "ArticleGroups",
                column: "ArticleGroupDaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleGroups_HigherLevelArticleGroupId",
                table: "ArticleGroups",
                column: "HigherLevelArticleGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleGroups_ArticleGroups_ArticleGroupDaoId",
                table: "ArticleGroups",
                column: "ArticleGroupDaoId",
                principalTable: "ArticleGroups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleGroups_ArticleGroups_ArticleGroupDaoId",
                table: "ArticleGroups");

            migrationBuilder.DropIndex(
                name: "IX_ArticleGroups_ArticleGroupDaoId",
                table: "ArticleGroups");

            migrationBuilder.DropIndex(
                name: "IX_ArticleGroups_HigherLevelArticleGroupId",
                table: "ArticleGroups");

            migrationBuilder.DropColumn(
                name: "ArticleGroupDaoId",
                table: "ArticleGroups");

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
                name: "IX_ArticleGroups_HigherLevelArticleGroupId",
                table: "ArticleGroups",
                column: "HigherLevelArticleGroupId",
                unique: true,
                filter: "[HigherLevelArticleGroupId] IS NOT NULL");
        }
    }
}
