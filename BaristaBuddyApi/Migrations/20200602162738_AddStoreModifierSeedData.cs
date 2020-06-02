using Microsoft.EntityFrameworkCore.Migrations;

namespace BaristaBuddyApi.Migrations
{
    public partial class AddStoreModifierSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreModifierModifierId",
                table: "Store",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreModifierStoreId",
                table: "Store",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreModifierModifierId",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreModifierStoreId",
                table: "Item",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StoreModifier",
                columns: table => new
                {
                    ModifierId = table.Column<int>(nullable: false),
                    StoreId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreModifier", x => new { x.ModifierId, x.StoreId });
                });

            migrationBuilder.InsertData(
                table: "StoreModifier",
                columns: new[] { "ModifierId", "StoreId", "Description", "Name" },
                values: new object[] { 1, 1, null, "Mint" });

            migrationBuilder.InsertData(
                table: "StoreModifier",
                columns: new[] { "ModifierId", "StoreId", "Description", "Name" },
                values: new object[] { 2, 1, null, "Espresso Shot" });

            migrationBuilder.InsertData(
                table: "StoreModifier",
                columns: new[] { "ModifierId", "StoreId", "Description", "Name" },
                values: new object[] { 3, 2, null, "Caramel" });

            migrationBuilder.CreateIndex(
                name: "IX_Store_StoreModifierModifierId_StoreModifierStoreId",
                table: "Store",
                columns: new[] { "StoreModifierModifierId", "StoreModifierStoreId" });

            migrationBuilder.CreateIndex(
                name: "IX_Item_StoreModifierModifierId_StoreModifierStoreId",
                table: "Item",
                columns: new[] { "StoreModifierModifierId", "StoreModifierStoreId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Item_StoreModifier_StoreModifierModifierId_StoreModifierStoreId",
                table: "Item",
                columns: new[] { "StoreModifierModifierId", "StoreModifierStoreId" },
                principalTable: "StoreModifier",
                principalColumns: new[] { "ModifierId", "StoreId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Store_StoreModifier_StoreModifierModifierId_StoreModifierStoreId",
                table: "Store",
                columns: new[] { "StoreModifierModifierId", "StoreModifierStoreId" },
                principalTable: "StoreModifier",
                principalColumns: new[] { "ModifierId", "StoreId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_StoreModifier_StoreModifierModifierId_StoreModifierStoreId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_StoreModifier_StoreModifierModifierId_StoreModifierStoreId",
                table: "Store");

            migrationBuilder.DropTable(
                name: "StoreModifier");

            migrationBuilder.DropIndex(
                name: "IX_Store_StoreModifierModifierId_StoreModifierStoreId",
                table: "Store");

            migrationBuilder.DropIndex(
                name: "IX_Item_StoreModifierModifierId_StoreModifierStoreId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "StoreModifierModifierId",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "StoreModifierStoreId",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "StoreModifierModifierId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "StoreModifierStoreId",
                table: "Item");
        }
    }
}
