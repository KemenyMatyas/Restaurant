using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.DataAccess.Migrations
{
    public partial class roleToEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_UserRoleGuid",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserRoleGuid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserRoleGuid",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserRole",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "UserRoleGuid",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Guid);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Guid", "Name" },
                values: new object[,]
                {
                    { new Guid("912334a5-f27c-4620-be49-fb992fc89099"), "Admin" },
                    { new Guid("baaf5e12-646e-4d2b-aca8-12ac5894eb52"), "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleGuid",
                table: "Users",
                column: "UserRoleGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_UserRoleGuid",
                table: "Users",
                column: "UserRoleGuid",
                principalTable: "Roles",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
