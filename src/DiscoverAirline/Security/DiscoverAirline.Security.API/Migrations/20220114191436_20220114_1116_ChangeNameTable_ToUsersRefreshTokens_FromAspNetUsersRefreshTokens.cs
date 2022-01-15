using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscoverAirline.Security.API.Migrations
{
    public partial class _20220114_1116_ChangeNameTable_ToUsersRefreshTokens_FromAspNetUsersRefreshTokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRefreshTokens_AspNetUsers_UserId",
                table: "UserRefreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRefreshTokens",
                table: "UserRefreshTokens");

            migrationBuilder.RenameTable(
                name: "UserRefreshTokens",
                newName: "AspNetUsersRefreshTokens");

            migrationBuilder.RenameIndex(
                name: "IX_UserRefreshTokens_UserId",
                table: "AspNetUsersRefreshTokens",
                newName: "IX_AspNetUsersRefreshTokens_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsersRefreshTokens",
                table: "AspNetUsersRefreshTokens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsersRefreshTokens_AspNetUsers_UserId",
                table: "AspNetUsersRefreshTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsersRefreshTokens_AspNetUsers_UserId",
                table: "AspNetUsersRefreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsersRefreshTokens",
                table: "AspNetUsersRefreshTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsersRefreshTokens",
                newName: "UserRefreshTokens");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsersRefreshTokens_UserId",
                table: "UserRefreshTokens",
                newName: "IX_UserRefreshTokens_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRefreshTokens",
                table: "UserRefreshTokens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRefreshTokens_AspNetUsers_UserId",
                table: "UserRefreshTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
