using Microsoft.EntityFrameworkCore.Migrations;

namespace BaristaBuddyApi.Migrations
{
    public partial class CleanSlate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    StoreImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Ingredients = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Item_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreModifier",
                columns: table => new
                {
                    ModifierId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreModifier", x => x.ModifierId);
                    table.ForeignKey(
                        name: "FK_StoreModifier_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "itemModifier",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false),
                    ModifierId = table.Column<int>(nullable: false),
                    AdditionalCost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemModifier", x => new { x.ItemId, x.ModifierId });
                    table.ForeignKey(
                        name: "FK_itemModifier_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_itemModifier_StoreModifier_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "StoreModifier",
                        principalColumn: "ModifierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "Id", "City", "Name", "Phone", "State", "StoreImageUrl", "StreetAddress", "WebsiteUrl", "Zip" },
                values: new object[] { 1, "Iowa City", "Matt's Place", null, "Iowa", null, "1918 H St.", null, "52240" });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "Id", "City", "Name", "Phone", "State", "StoreImageUrl", "StreetAddress", "WebsiteUrl", "Zip" },
                values: new object[] { 2, "Cedar Rapids", "Roastopia", null, "Iowa", null, "1313 1st Ave.", null, "52240" });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "Id", "City", "Name", "Phone", "State", "StoreImageUrl", "StreetAddress", "WebsiteUrl", "Zip" },
                values: new object[] { 3, "Des Moines", "King Keith's Cafe", null, "Iowa", null, "121 Dodge St.", null, "52240" });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "ItemId", "ImageUrl", "Ingredients", "Name", "Price", "StoreId" },
                values: new object[,]
                {
                    { 1, null, "Almond Milk, Cocoa nibs, Honey, Cinnamon", "Brennan's Hot Chocolate", 3.1299999999999999, 1 },
                    { 2, null, null, "Matt's Espresso Macchiato", 4.1699999999999999, 1 },
                    { 3, null, null, "Sihem's Caramel Latte", 4.0, 2 },
                    { 4, null, "Enough caffiene to kill a small horse", "James's Triple Death", 6.6600000000000001, 3 }
                });

            migrationBuilder.InsertData(
                table: "StoreModifier",
                columns: new[] { "ModifierId", "Description", "Name", "StoreId" },
                values: new object[,]
                {
                    { 1, null, "Mint", 1 },
                    { 2, null, "Espresso Shot", 1 },
                    { 3, null, "Caramel", 2 }
                });

            migrationBuilder.InsertData(
                table: "itemModifier",
                columns: new[] { "ItemId", "ModifierId", "AdditionalCost" },
                values: new object[] { 1, 1, 0.75 });

            migrationBuilder.InsertData(
                table: "itemModifier",
                columns: new[] { "ItemId", "ModifierId", "AdditionalCost" },
                values: new object[] { 3, 3, 0.75 });

            migrationBuilder.InsertData(
                table: "itemModifier",
                columns: new[] { "ItemId", "ModifierId", "AdditionalCost" },
                values: new object[] { 4, 2, 1.5 });

            migrationBuilder.CreateIndex(
                name: "IX_Item_StoreId",
                table: "Item",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_itemModifier_ModifierId",
                table: "itemModifier",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreModifier_StoreId",
                table: "StoreModifier",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "itemModifier");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "StoreModifier");

            migrationBuilder.DropTable(
                name: "Store");
        }
    }
}
