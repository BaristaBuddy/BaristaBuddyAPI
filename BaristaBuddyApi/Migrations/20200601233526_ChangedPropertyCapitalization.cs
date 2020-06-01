using Microsoft.EntityFrameworkCore.Migrations;

namespace BaristaBuddyApi.Migrations
{
    public partial class ChangedPropertyCapitalization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "state",
                table: "Store",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "WebSiteUrl",
                table: "Store",
                newName: "WebsiteUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WebsiteUrl",
                table: "Store",
                newName: "WebSiteUrl");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Store",
                newName: "state");
        }
    }
}
