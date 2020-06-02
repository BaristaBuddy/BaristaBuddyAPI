using Microsoft.EntityFrameworkCore.Migrations;

namespace BaristaBuddyApi.Migrations
{
    public partial class SeedStoreTable : Migration
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
                    state = table.Column<string>(nullable: false),
                    Zip = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    WebSiteUrl = table.Column<string>(nullable: true),
                    StoreImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "Id", "City", "Name", "Phone", "StoreImageUrl", "StreetAddress", "WebSiteUrl", "Zip", "state" },
                values: new object[] { 1, "iowa city", "matt's Place", null, null, "1918 H st", null, "52240", "iowa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Store");
        }
    }
}
