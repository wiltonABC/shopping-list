using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GroceryList.Migrations
{
    public partial class V8_21012020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListItem_Product_ProductId",
                table: "ListItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ListItem_ShoppingList_ShoppingListId",
                table: "ListItem");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ShoppingList",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingListId",
                table: "ListItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ListItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ListItem_Product_ProductId",
                table: "ListItem",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListItem_ShoppingList_ShoppingListId",
                table: "ListItem",
                column: "ShoppingListId",
                principalTable: "ShoppingList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListItem_Product_ProductId",
                table: "ListItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ListItem_ShoppingList_ShoppingListId",
                table: "ListItem");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ShoppingList",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingListId",
                table: "ListItem",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ListItem",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ListItem_Product_ProductId",
                table: "ListItem",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListItem_ShoppingList_ShoppingListId",
                table: "ListItem",
                column: "ShoppingListId",
                principalTable: "ShoppingList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
