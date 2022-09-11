using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.DataAccess.Migrations
{
    public partial class categoryManyToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryMenu");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "CategoryMenu",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    MenuItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryMenu", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_CategoryMenu_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryMenu_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMenu_CategoryId",
                table: "CategoryMenu",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMenu_MenuItemId",
                table: "CategoryMenu",
                column: "MenuItemId");
        }
    }
}
