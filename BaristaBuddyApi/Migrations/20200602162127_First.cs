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

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Zip = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    WebsiteUrl = table.Column<string>(nullable: true),
                    StoreImageUrl = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: true),
                    ItemStoreId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Store_Item_ItemId_ItemStoreId",
                        columns: x => new { x.ItemId, x.ItemStoreId },
                        principalTable: "Item",
                        principalColumns: new[] { "ItemId", "StoreId" },
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "Id", "City", "ItemId", "ItemStoreId", "Name", "Phone", "State", "StoreImageUrl", "StreetAddress", "WebsiteUrl", "Zip" },
                values: new object[,]
                {
                    { 1, "Iowa City", null, null, "Matt's Place", null, "Iowa", null, "1918 H St.", null, "52240" },
                    { 2, "Cedar Rapids", null, null, "Roastopia", null, "Iowa", null, "1313 1st Ave.", null, "52240" },
                    { 3, "Des Moines", null, null, "King Keith's Cafe", null, "Iowa", null, "121 Dodge St.", null, "52240" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Store_ItemId_ItemStoreId",
                table: "Store",
                columns: new[] { "ItemId", "ItemStoreId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Item");
        }
    }
}
