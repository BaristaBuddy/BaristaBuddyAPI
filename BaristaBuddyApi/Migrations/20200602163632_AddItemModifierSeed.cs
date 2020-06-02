using Microsoft.EntityFrameworkCore.Migrations;

namespace BaristaBuddyApi.Migrations
{
    public partial class AddItemModifierSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemModifierItemId",
                table: "StoreModifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemModifierModifierId",
                table: "StoreModifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemModifierItemId",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemModifierModifierId",
                table: "Item",
                nullable: true);

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
                });

            migrationBuilder.InsertData(
                table: "itemModifier",
                columns: new[] { "ItemId", "ModifierId", "AdditionalCost" },
                values: new object[] { 1, 1, 0.75 });

            migrationBuilder.InsertData(
                table: "itemModifier",
                columns: new[] { "ItemId", "ModifierId", "AdditionalCost" },
                values: new object[] { 4, 2, 1.5 });

            migrationBuilder.InsertData(
                table: "itemModifier",
                columns: new[] { "ItemId", "ModifierId", "AdditionalCost" },
                values: new object[] { 3, 3, 0.75 });

            migrationBuilder.CreateIndex(
                name: "IX_StoreModifier_ItemModifierItemId_ItemModifierModifierId",
                table: "StoreModifier",
                columns: new[] { "ItemModifierItemId", "ItemModifierModifierId" });

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemModifierItemId_ItemModifierModifierId",
                table: "Item",
                columns: new[] { "ItemModifierItemId", "ItemModifierModifierId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Item_itemModifier_ItemModifierItemId_ItemModifierModifierId",
                table: "Item",
                columns: new[] { "ItemModifierItemId", "ItemModifierModifierId" },
                principalTable: "itemModifier",
                principalColumns: new[] { "ItemId", "ModifierId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreModifier_itemModifier_ItemModifierItemId_ItemModifierModifierId",
                table: "StoreModifier",
                columns: new[] { "ItemModifierItemId", "ItemModifierModifierId" },
                principalTable: "itemModifier",
                principalColumns: new[] { "ItemId", "ModifierId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_itemModifier_ItemModifierItemId_ItemModifierModifierId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreModifier_itemModifier_ItemModifierItemId_ItemModifierModifierId",
                table: "StoreModifier");

            migrationBuilder.DropTable(
                name: "itemModifier");

            migrationBuilder.DropIndex(
                name: "IX_StoreModifier_ItemModifierItemId_ItemModifierModifierId",
                table: "StoreModifier");

            migrationBuilder.DropIndex(
                name: "IX_Item_ItemModifierItemId_ItemModifierModifierId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ItemModifierItemId",
                table: "StoreModifier");

            migrationBuilder.DropColumn(
                name: "ItemModifierModifierId",
                table: "StoreModifier");

            migrationBuilder.DropColumn(
                name: "ItemModifierItemId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ItemModifierModifierId",
                table: "Item");
        }
    }
}
