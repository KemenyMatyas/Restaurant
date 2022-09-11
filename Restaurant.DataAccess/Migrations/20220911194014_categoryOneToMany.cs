using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.DataAccess.Migrations
{
    public partial class categoryOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_MenuItems_MenuItemGuid",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_MenuItemGuid",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "MenuItemGuid",
                table: "Categories");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryGuid",
                table: "MenuItems",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CategoryGuid",
                table: "MenuItems",
                column: "CategoryGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Categories_CategoryGuid",
                table: "MenuItems",
                column: "CategoryGuid",
                principalTable: "Categories",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Categories_CategoryGuid",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_CategoryGuid",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "CategoryGuid",
                table: "MenuItems");

            migrationBuilder.AddColumn<Guid>(
                name: "MenuItemGuid",
                table: "Categories",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MenuItemGuid",
                table: "Categories",
                column: "MenuItemGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_MenuItems_MenuItemGuid",
                table: "Categories",
                column: "MenuItemGuid",
                principalTable: "MenuItems",
                principalColumn: "Guid");
        }
    }
}
