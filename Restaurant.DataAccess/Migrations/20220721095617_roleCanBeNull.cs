using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.DataAccess.Migrations
{
    public partial class roleCanBeNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_UserRoleGuid",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserRoleGuid",
                table: "Users",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_UserRoleGuid",
                table: "Users",
                column: "UserRoleGuid",
                principalTable: "Roles",
                principalColumn: "Guid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_UserRoleGuid",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserRoleGuid",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

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
