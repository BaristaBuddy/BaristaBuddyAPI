using Microsoft.EntityFrameworkCore.Migrations;

namespace BaristaBuddyApi.Migrations
{
    public partial class SeededTwoMoreStores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "Name", "State", "StreetAddress" },
                values: new object[] { "Iowa City", "Matt's Place", "Iowa", "1918 H St." });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "Id", "City", "Name", "Phone", "State", "StoreImageUrl", "StreetAddress", "WebsiteUrl", "Zip" },
                values: new object[] { 3, "Des Moines", "King Keith's Cafe", null, "Iowa", null, "121 Dodge St.", null, "52240" });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "Id", "City", "Name", "Phone", "State", "StoreImageUrl", "StreetAddress", "WebsiteUrl", "Zip" },
                values: new object[] { 2, "Cedar Rapids", "Roastopia", null, "Iowa", null, "1313 1st Ave.", null, "52240" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "Name", "State", "StreetAddress" },
                values: new object[] { "iowa city", "matt's Place", "iowa", "1918 H st" });
        }
    }
}
