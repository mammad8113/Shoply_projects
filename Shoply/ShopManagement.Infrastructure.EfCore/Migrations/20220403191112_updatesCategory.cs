using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Infrastructure.EfCore.Migrations
{
    public partial class updatesCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_ProductCategories_ParentId",
                table: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_ParentId",
                table: "ProductCategories");

            migrationBuilder.AddColumn<long>(
                name: "CategoryParentId",
                table: "ProductCategories",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryParentId",
                table: "ProductCategories",
                column: "CategoryParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_ProductCategories_CategoryParentId",
                table: "ProductCategories",
                column: "CategoryParentId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_ProductCategories_CategoryParentId",
                table: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_CategoryParentId",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "CategoryParentId",
                table: "ProductCategories");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ParentId",
                table: "ProductCategories",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_ProductCategories_ParentId",
                table: "ProductCategories",
                column: "ParentId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
