using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaristaBuddyApi.Migrations
{
    public partial class AddStoreIdToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Order",
                nullable: false,
                defaultValue: 1);

          

            migrationBuilder.CreateIndex(
                name: "IX_Order_StoreId",
                table: "Order",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Store_StoreId",
                table: "Order",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Store_StoreId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_StoreId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Order");

  
        }
    }
}
