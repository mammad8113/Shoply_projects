using Microsoft.EntityFrameworkCore.Migrations;

namespace CommentManagement.Infrastructure.EfCore.Migrations
{
    public partial class changComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Comments",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Comments",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
