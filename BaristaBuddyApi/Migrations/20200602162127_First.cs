using Microsoft.EntityFrameworkCore.Migrations;



namespace BaristaBuddyApi.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false),
                    StoreId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Ingredients = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => new { x.ItemId, x.StoreId });
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "ItemId", "StoreId", "ImageUrl", "Ingredients", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, null, "Almond Milk, Cocoa nibs, Honey, Cinnamon", "Brennan's Hot Chocolate", 3.1299999999999999 },
                    { 2, 1, null, null, "Matt's Espresso Macchiato", 4.1699999999999999 },
                    { 3, 2, null, null, "Sihem's Caramel Latte", 4.0 },
                    { 4, 3, null, "Enough caffiene to kill a small horse", "James's Triple Death", 6.6600000000000001 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");
        }
    }
}
