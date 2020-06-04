using Microsoft.EntityFrameworkCore.Migrations;

namespace BaristaBuddyApi.Migrations
{
    public partial class AddItemSizeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemSize",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false),
                    Size = table.Column<string>(nullable: false),
                    AdditionalCost = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSize", x => new { x.ItemId, x.Size });
                    table.ForeignKey(
                        name: "FK_ItemSize_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ItemSize",
                columns: new[] { "ItemId", "Size", "AdditionalCost" },
                values: new object[,]
                {
                    { 1, "Dwarf", 0m },
                    { 1, "Human", 0.50m },
                    { 1, "Giant", 1.00m },
                    { 2, "Dwarf", 0m },
                    { 2, "Human", 0.50m },
                    { 2, "Giant", 1.00m },
                    { 3, "Dwarf", 0m },
                    { 3, "Human", 0.50m },
                    { 3, "Giant", 1.00m },
                    { 4, "Dwarf", 0m },
                    { 4, "Human", 0.50m },
                    { 4, "Giant", 1.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemSize");
        }
    }
}
