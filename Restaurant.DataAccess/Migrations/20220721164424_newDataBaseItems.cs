using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.DataAccess.Migrations
{
    public partial class newDataBaseItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Users",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "AddressGuid",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    CostumerGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    DeliveryAddressGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    DeliveryTime = table.Column<int>(type: "integer", nullable: false),
                    FinalPrice = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_DeliveryAddressGuid",
                        column: x => x.DeliveryAddressGuid,
                        principalTable: "Addresses",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_CostumerGuid",
                        column: x => x.CostumerGuid,
                        principalTable: "Users",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientMenuItem",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    IngredientId = table.Column<Guid>(type: "uuid", nullable: false),
                    MenuItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientMenuItem", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_IngredientMenuItem_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientMenuItem_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderMenuItem",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    OderId = table.Column<Guid>(type: "uuid", nullable: false),
                    MenuItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMenuItem", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_OrderMenuItem_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderMenuItem_Orders_OderId",
                        column: x => x.OderId,
                        principalTable: "Orders",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressGuid",
                table: "Users",
                column: "AddressGuid");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientMenuItem_IngredientId",
                table: "IngredientMenuItem",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientMenuItem_MenuItemId",
                table: "IngredientMenuItem",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMenuItem_MenuItemId",
                table: "OrderMenuItem",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMenuItem_OderId",
                table: "OrderMenuItem",
                column: "OderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CostumerGuid",
                table: "Orders",
                column: "CostumerGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryAddressGuid",
                table: "Orders",
                column: "DeliveryAddressGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Addresses_AddressGuid",
                table: "Users",
                column: "AddressGuid",
                principalTable: "Addresses",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Addresses_AddressGuid",
                table: "Users");

            migrationBuilder.DropTable(
                name: "IngredientMenuItem");

            migrationBuilder.DropTable(
                name: "OrderMenuItem");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Users_AddressGuid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AddressGuid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Users",
                newName: "FullName");
        }
    }
}
