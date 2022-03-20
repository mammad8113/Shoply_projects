using Microsoft.EntityFrameworkCore.Migrations;

namespace AcountManagement.Infrastructure.EfCore.Migrations
{
    public partial class relationAcountForRol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Acounts_RolId",
                table: "Acounts",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acounts_Rols_RolId",
                table: "Acounts",
                column: "RolId",
                principalTable: "Rols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acounts_Rols_RolId",
                table: "Acounts");

            migrationBuilder.DropIndex(
                name: "IX_Acounts_RolId",
                table: "Acounts");
        }
    }
}
