using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Infrastructure.EfCore.Migrations
{
    public partial class childparentCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "Parent",
                table: "ProductCategories");

            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "ProductCategories",
                type: "bigint",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_ProductCategories_ParentId",
                table: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_ParentId",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "ProductCategories");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "ProductCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "Parent",
                table: "ProductCategories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
