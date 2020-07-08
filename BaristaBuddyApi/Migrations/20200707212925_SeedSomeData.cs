using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaristaBuddyApi.Migrations
{
    public partial class SeedSomeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "OrderTime", "PickupName", "PickupTime", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 7, 7, 21, 29, 25, 375, DateTimeKind.Utc).AddTicks(4300), "sihem", new DateTime(2020, 7, 7, 21, 29, 25, 375, DateTimeKind.Utc).AddTicks(4751), null },
                    { 2, new DateTime(2020, 7, 7, 21, 29, 25, 375, DateTimeKind.Utc).AddTicks(5119), "brannan", new DateTime(2020, 7, 7, 21, 29, 25, 375, DateTimeKind.Utc).AddTicks(5127), null },
                    { 3, new DateTime(2020, 7, 7, 21, 29, 25, 375, DateTimeKind.Utc).AddTicks(5134), "matt", new DateTime(2020, 7, 7, 21, 29, 25, 375, DateTimeKind.Utc).AddTicks(5135), null },
                    { 4, new DateTime(2020, 7, 7, 21, 29, 25, 375, DateTimeKind.Utc).AddTicks(5136), "james", new DateTime(2020, 7, 7, 21, 29, 25, 375, DateTimeKind.Utc).AddTicks(5137), null }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "AdditionalCost", "ItemId", "OrderId", "Quantity", "Size" },
                values: new object[,]
                {
                    { 1, 0m, 2, 1, 1, null },
                    { 2, 0m, 3, 1, 1, null },
                    { 3, 0m, 4, 2, 1, null },
                    { 4, 0m, 4, 3, 1, null },
                    { 5, 0m, 4, 4, 1, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
