using Microsoft.EntityFrameworkCore.Migrations;

namespace AcountManagement.Infrastructure.EfCore.Migrations
{
    public partial class ignorName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Permissions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Permissions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
