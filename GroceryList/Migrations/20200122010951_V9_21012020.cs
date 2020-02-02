using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GroceryList.Migrations
{
    public partial class V9_21012020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupermarketId",
                table: "ShoppingList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ListItem",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Category",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.CreateTable(
                name: "Supermarket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supermarket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupermarketCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    SupermarketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupermarketCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupermarketCategories_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupermarketCategories_Supermarket_SupermarketId",
                        column: x => x.SupermarketId,
                        principalTable: "Supermarket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingList_SupermarketId",
                table: "ShoppingList",
                column: "SupermarketId");

            migrationBuilder.CreateIndex(
                name: "IX_SupermarketCategories_CategoryId",
                table: "SupermarketCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SupermarketCategories_SupermarketId",
                table: "SupermarketCategories",
                column: "SupermarketId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingList_Supermarket_SupermarketId",
                table: "ShoppingList",
                column: "SupermarketId",
                principalTable: "Supermarket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingList_Supermarket_SupermarketId",
                table: "ShoppingList");

            migrationBuilder.DropTable(
                name: "SupermarketCategories");

            migrationBuilder.DropTable(
                name: "Supermarket");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingList_SupermarketId",
                table: "ShoppingList");

            migrationBuilder.DropColumn(
                name: "SupermarketId",
                table: "ShoppingList");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ListItem");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Category");
        }
    }
}
