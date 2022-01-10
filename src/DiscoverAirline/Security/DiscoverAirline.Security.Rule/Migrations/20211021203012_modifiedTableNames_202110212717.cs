using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscoverAirline.Security.Rule.Migrations
{
    public partial class modifiedTableNames_202110212717 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authorizations_Controllers_ControllerId",
                table: "Authorizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Authorizations_Services_ServiceId",
                table: "Authorizations");

            migrationBuilder.DropTable(
                name: "Controllers");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Authorizations",
                newName: "ApplicationId");

            migrationBuilder.RenameColumn(
                name: "ControllerId",
                table: "Authorizations",
                newName: "AccessId");

            migrationBuilder.RenameIndex(
                name: "IX_Authorizations_ServiceId",
                table: "Authorizations",
                newName: "IX_Authorizations_ApplicationId");

            migrationBuilder.RenameIndex(
                name: "IX_Authorizations_ControllerId",
                table: "Authorizations",
                newName: "IX_Authorizations_AccessId");

            migrationBuilder.CreateTable(
                name: "Access",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Access", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Authorizations_Access_AccessId",
                table: "Authorizations",
                column: "AccessId",
                principalTable: "Access",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Authorizations_Applications_ApplicationId",
                table: "Authorizations",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authorizations_Access_AccessId",
                table: "Authorizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Authorizations_Applications_ApplicationId",
                table: "Authorizations");

            migrationBuilder.DropTable(
                name: "Access");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.RenameColumn(
                name: "ApplicationId",
                table: "Authorizations",
                newName: "ServiceId");

            migrationBuilder.RenameColumn(
                name: "AccessId",
                table: "Authorizations",
                newName: "ControllerId");

            migrationBuilder.RenameIndex(
                name: "IX_Authorizations_ApplicationId",
                table: "Authorizations",
                newName: "IX_Authorizations_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Authorizations_AccessId",
                table: "Authorizations",
                newName: "IX_Authorizations_ControllerId");

            migrationBuilder.CreateTable(
                name: "Controllers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Controllers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Authorizations_Controllers_ControllerId",
                table: "Authorizations",
                column: "ControllerId",
                principalTable: "Controllers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Authorizations_Services_ServiceId",
                table: "Authorizations",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
