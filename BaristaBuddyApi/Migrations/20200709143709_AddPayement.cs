using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaristaBuddyApi.Migrations
{
    public partial class AddPayement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OrderTime", "PickupTime" },
                values: new object[] { new DateTime(2020, 7, 9, 14, 37, 8, 675, DateTimeKind.Utc).AddTicks(7603), new DateTime(2020, 7, 9, 14, 37, 8, 675, DateTimeKind.Utc).AddTicks(8193) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "OrderTime", "PickupTime" },
                values: new object[] { new DateTime(2020, 7, 9, 14, 37, 8, 675, DateTimeKind.Utc).AddTicks(8603), new DateTime(2020, 7, 9, 14, 37, 8, 675, DateTimeKind.Utc).AddTicks(8614) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "OrderTime", "PickupTime" },
                values: new object[] { new DateTime(2020, 7, 9, 14, 37, 8, 675, DateTimeKind.Utc).AddTicks(8631), new DateTime(2020, 7, 9, 14, 37, 8, 675, DateTimeKind.Utc).AddTicks(8632) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "OrderTime", "PickupTime" },
                values: new object[] { new DateTime(2020, 7, 9, 14, 37, 8, 675, DateTimeKind.Utc).AddTicks(8633), new DateTime(2020, 7, 9, 14, 37, 8, 675, DateTimeKind.Utc).AddTicks(8634) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OrderTime", "PickupTime" },
                values: new object[] { new DateTime(2020, 7, 8, 19, 23, 7, 390, DateTimeKind.Utc).AddTicks(5821), new DateTime(2020, 7, 8, 19, 23, 7, 390, DateTimeKind.Utc).AddTicks(7046) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "OrderTime", "PickupTime" },
                values: new object[] { new DateTime(2020, 7, 8, 19, 23, 7, 390, DateTimeKind.Utc).AddTicks(7949), new DateTime(2020, 7, 8, 19, 23, 7, 390, DateTimeKind.Utc).AddTicks(7976) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "OrderTime", "PickupTime" },
                values: new object[] { new DateTime(2020, 7, 8, 19, 23, 7, 390, DateTimeKind.Utc).AddTicks(8001), new DateTime(2020, 7, 8, 19, 23, 7, 390, DateTimeKind.Utc).AddTicks(8003) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "OrderTime", "PickupTime" },
                values: new object[] { new DateTime(2020, 7, 8, 19, 23, 7, 390, DateTimeKind.Utc).AddTicks(8006), new DateTime(2020, 7, 8, 19, 23, 7, 390, DateTimeKind.Utc).AddTicks(8008) });
        }
    }
}
