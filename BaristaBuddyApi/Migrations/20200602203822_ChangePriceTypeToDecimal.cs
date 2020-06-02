using Microsoft.EntityFrameworkCore.Migrations;

namespace BaristaBuddyApi.Migrations
{
    public partial class ChangePriceTypeToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "AdditionalCost",
                table: "itemModifier",
                type: "money",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Item",
                type: "money",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "Price",
                value: 3.13m);

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemId",
                keyValue: 2,
                column: "Price",
                value: 4.17m);

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemId",
                keyValue: 3,
                column: "Price",
                value: 4.00m);

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemId",
                keyValue: 4,
                column: "Price",
                value: 6.66m);

            migrationBuilder.UpdateData(
                table: "itemModifier",
                keyColumns: new[] { "ItemId", "ModifierId" },
                keyValues: new object[] { 1, 1 },
                column: "AdditionalCost",
                value: 0.75m);

            migrationBuilder.UpdateData(
                table: "itemModifier",
                keyColumns: new[] { "ItemId", "ModifierId" },
                keyValues: new object[] { 3, 3 },
                column: "AdditionalCost",
                value: 0.75m);

            migrationBuilder.UpdateData(
                table: "itemModifier",
                keyColumns: new[] { "ItemId", "ModifierId" },
                keyValues: new object[] { 4, 2 },
                column: "AdditionalCost",
                value: 1.50m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "AdditionalCost",
                table: "itemModifier",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Item",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "Price",
                value: 3.1299999999999999);

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemId",
                keyValue: 2,
                column: "Price",
                value: 4.1699999999999999);

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemId",
                keyValue: 3,
                column: "Price",
                value: 4.0);

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemId",
                keyValue: 4,
                column: "Price",
                value: 6.6600000000000001);

            migrationBuilder.UpdateData(
                table: "itemModifier",
                keyColumns: new[] { "ItemId", "ModifierId" },
                keyValues: new object[] { 1, 1 },
                column: "AdditionalCost",
                value: 0.75);

            migrationBuilder.UpdateData(
                table: "itemModifier",
                keyColumns: new[] { "ItemId", "ModifierId" },
                keyValues: new object[] { 3, 3 },
                column: "AdditionalCost",
                value: 0.75);

            migrationBuilder.UpdateData(
                table: "itemModifier",
                keyColumns: new[] { "ItemId", "ModifierId" },
                keyValues: new object[] { 4, 2 },
                column: "AdditionalCost",
                value: 1.5);
        }
    }
}
