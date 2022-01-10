using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscoverAirline.Security.Rule.Migrations
{
    public partial class refactorInAuthorizationTables_202110181020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authorizations_Actions_RoleId",
                table: "Authorizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Authorizations_Controllers_RoleId",
                table: "Authorizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Authorizations_Services_RoleId",
                table: "Authorizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Controllers_Services_ServiceId",
                table: "Controllers");

            migrationBuilder.DropTable(
                name: "ActionController");

            migrationBuilder.DropIndex(
                name: "IX_Controllers_ServiceId",
                table: "Controllers");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Controllers");

            migrationBuilder.CreateIndex(
                name: "IX_Authorizations_ActionId",
                table: "Authorizations",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Authorizations_ControllerId",
                table: "Authorizations",
                column: "ControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_Authorizations_ServiceId",
                table: "Authorizations",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authorizations_Actions_ActionId",
                table: "Authorizations",
                column: "ActionId",
                principalTable: "Actions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authorizations_Actions_ActionId",
                table: "Authorizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Authorizations_Controllers_ControllerId",
                table: "Authorizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Authorizations_Services_ServiceId",
                table: "Authorizations");

            migrationBuilder.DropIndex(
                name: "IX_Authorizations_ActionId",
                table: "Authorizations");

            migrationBuilder.DropIndex(
                name: "IX_Authorizations_ControllerId",
                table: "Authorizations");

            migrationBuilder.DropIndex(
                name: "IX_Authorizations_ServiceId",
                table: "Authorizations");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Controllers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ActionController",
                columns: table => new
                {
                    ActionsId = table.Column<int>(type: "int", nullable: false),
                    ControllersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionController", x => new { x.ActionsId, x.ControllersId });
                    table.ForeignKey(
                        name: "FK_ActionController_Actions_ActionsId",
                        column: x => x.ActionsId,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActionController_Controllers_ControllersId",
                        column: x => x.ControllersId,
                        principalTable: "Controllers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Controllers_ServiceId",
                table: "Controllers",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionController_ControllersId",
                table: "ActionController",
                column: "ControllersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authorizations_Actions_RoleId",
                table: "Authorizations",
                column: "RoleId",
                principalTable: "Actions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Authorizations_Controllers_RoleId",
                table: "Authorizations",
                column: "RoleId",
                principalTable: "Controllers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Authorizations_Services_RoleId",
                table: "Authorizations",
                column: "RoleId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Controllers_Services_ServiceId",
                table: "Controllers",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
