using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.DataAccess.Migrations
{
    public partial class menuItemIdFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMenu_MenuItems_MenuItemGuid",
                table: "CategoryMenu");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "CategoryMenu");

            migrationBuilder.RenameColumn(
                name: "MenuItemGuid",
                table: "CategoryMenu",
                newName: "MenuItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryMenu_MenuItemGuid",
                table: "CategoryMenu",
                newName: "IX_CategoryMenu_MenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMenu_MenuItems_MenuItemId",
                table: "CategoryMenu",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMenu_MenuItems_MenuItemId",
                table: "CategoryMenu");

            migrationBuilder.RenameColumn(
                name: "MenuItemId",
                table: "CategoryMenu",
                newName: "MenuItemGuid");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryMenu_MenuItemId",
                table: "CategoryMenu",
                newName: "IX_CategoryMenu_MenuItemGuid");

            migrationBuilder.AddColumn<Guid>(
                name: "MenuId",
                table: "CategoryMenu",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMenu_MenuItems_MenuItemGuid",
                table: "CategoryMenu",
                column: "MenuItemGuid",
                principalTable: "MenuItems",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
