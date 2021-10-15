using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscoverAirline.Security.Rule.Migrations
{
    public partial class tableToken_changeColumnDateExpiration_FromExpirationDate_202110132623 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateExpiration",
                table: "Tokens",
                newName: "ExpirationDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpirationDate",
                table: "Tokens",
                newName: "DateExpiration");
        }
    }
}
