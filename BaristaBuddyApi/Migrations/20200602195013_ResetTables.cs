using Microsoft.EntityFrameworkCore.Migrations;

namespace BaristaBuddyApi.Migrations
{
    public partial class ResetTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "StoreModifier");

            migrationBuilder.DropTable(
                name: "itemModifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "itemModifier",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: false),
                    AdditionalCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemModifier", x => new { x.ItemId, x.ModifierId });
                });

            migrationBuilder.CreateTable(
                name: "StoreModifier",
                columns: table => new
                {
                    ModifierId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemModifierItemId = table.Column<int>(type: "int", nullable: true),
                    ItemModifierModifierId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreModifier", x => new { x.ModifierId, x.StoreId });
                    table.ForeignKey(
                        name: "FK_StoreModifier_itemModifier_ItemModifierItemId_ItemModifierModifierId",
                        columns: x => new { x.ItemModifierItemId, x.ItemModifierModifierId },
                        principalTable: "itemModifier",
                        principalColumns: new[] { "ItemId", "ModifierId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemModifierItemId = table.Column<int>(type: "int", nullable: true),
                    ItemModifierModifierId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    StoreModifierModifierId = table.Column<int>(type: "int", nullable: true),
                    StoreModifierStoreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => new { x.ItemId, x.StoreId });
                    table.ForeignKey(
                        name: "FK_Item_itemModifier_ItemModifierItemId_ItemModifierModifierId",
                        columns: x => new { x.ItemModifierItemId, x.ItemModifierModifierId },
                        principalTable: "itemModifier",
                        principalColumns: new[] { "ItemId", "ModifierId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_StoreModifier_StoreModifierModifierId_StoreModifierStoreId",
                        columns: x => new { x.StoreModifierModifierId, x.StoreModifierStoreId },
                        principalTable: "StoreModifier",
                        principalColumns: new[] { "ModifierId", "StoreId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    ItemStoreId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreModifierModifierId = table.Column<int>(type: "int", nullable: true),
                    StoreModifierStoreId = table.Column<int>(type: "int", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Store_StoreModifier_StoreModifierModifierId_StoreModifierStoreId",
                        columns: x => new { x.StoreModifierModifierId, x.StoreModifierStoreId },
                        principalTable: "StoreModifier",
                        principalColumns: new[] { "ModifierId", "StoreId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "ItemId", "StoreId", "ImageUrl", "Ingredients", "ItemModifierItemId", "ItemModifierModifierId", "Name", "Price", "StoreModifierModifierId", "StoreModifierStoreId" },
                values: new object[,]
                {
                    { 1, 1, null, "Almond Milk, Cocoa nibs, Honey, Cinnamon", null, null, "Brennan's Hot Chocolate", 3.1299999999999999, null, null },
                    { 2, 1, null, null, null, null, "Matt's Espresso Macchiato", 4.1699999999999999, null, null },
                    { 3, 2, null, null, null, null, "Sihem's Caramel Latte", 4.0, null, null },
                    { 4, 3, null, "Enough caffiene to kill a small horse", null, null, "James's Triple Death", 6.6600000000000001, null, null }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "Id", "City", "ItemId", "ItemStoreId", "Name", "Phone", "State", "StoreImageUrl", "StoreModifierModifierId", "StoreModifierStoreId", "StreetAddress", "WebsiteUrl", "Zip" },
                values: new object[,]
                {
                    { 1, "Iowa City", null, null, "Matt's Place", null, "Iowa", null, null, null, "1918 H St.", null, "52240" },
                    { 2, "Cedar Rapids", null, null, "Roastopia", null, "Iowa", null, null, null, "1313 1st Ave.", null, "52240" },
                    { 3, "Des Moines", null, null, "King Keith's Cafe", null, "Iowa", null, null, null, "121 Dodge St.", null, "52240" }
                });

            migrationBuilder.InsertData(
                table: "StoreModifier",
                columns: new[] { "ModifierId", "StoreId", "Description", "ItemModifierItemId", "ItemModifierModifierId", "Name" },
                values: new object[,]
                {
                    { 1, 1, null, null, null, "Mint" },
                    { 2, 1, null, null, null, "Espresso Shot" },
                    { 3, 2, null, null, null, "Caramel" }
                });

            migrationBuilder.InsertData(
                table: "itemModifier",
                columns: new[] { "ItemId", "ModifierId", "AdditionalCost" },
                values: new object[,]
                {
                    { 1, 1, 0.75 },
                    { 4, 2, 1.5 },
                    { 3, 3, 0.75 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemModifierItemId_ItemModifierModifierId",
                table: "Item",
                columns: new[] { "ItemModifierItemId", "ItemModifierModifierId" });

            migrationBuilder.CreateIndex(
                name: "IX_Item_StoreModifierModifierId_StoreModifierStoreId",
                table: "Item",
                columns: new[] { "StoreModifierModifierId", "StoreModifierStoreId" });

            migrationBuilder.CreateIndex(
                name: "IX_Store_ItemId_ItemStoreId",
                table: "Store",
                columns: new[] { "ItemId", "ItemStoreId" });

            migrationBuilder.CreateIndex(
                name: "IX_Store_StoreModifierModifierId_StoreModifierStoreId",
                table: "Store",
                columns: new[] { "StoreModifierModifierId", "StoreModifierStoreId" });

            migrationBuilder.CreateIndex(
                name: "IX_StoreModifier_ItemModifierItemId_ItemModifierModifierId",
                table: "StoreModifier",
                columns: new[] { "ItemModifierItemId", "ItemModifierModifierId" });
        }
    }
}
