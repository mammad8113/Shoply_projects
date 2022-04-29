using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcountManagement.Infrastructure.EfCore.Migrations
{
    public partial class Acount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rols",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rols", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Acounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    UserPhoto = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    RolId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acounts_Rols_RolId",
                        column: x => x.RolId,
                        principalTable: "Rols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Rols_RolId",
                        column: x => x.RolId,
                        principalTable: "Rols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acounts_RolId",
                table: "Acounts",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RolId",
                table: "Permissions",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acounts");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Rols");
        }
    }
}
