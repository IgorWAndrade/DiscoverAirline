using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscoverAirline.Security.Rule.Migrations
{
    public partial class addTableManyToMany_202110202810 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authorizations",
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

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Authorizations");

            migrationBuilder.DropColumn(
                name: "ControllerId",
                table: "Authorizations");

            migrationBuilder.DropColumn(
                name: "ActionId",
                table: "Authorizations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authorizations",
                table: "Authorizations",
                column: "RoleId");

            migrationBuilder.CreateTable(
                name: "ActionAuthorization",
                columns: table => new
                {
                    ActionsId = table.Column<int>(type: "int", nullable: false),
                    AuthorizationsRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionAuthorization", x => new { x.ActionsId, x.AuthorizationsRoleId });
                    table.ForeignKey(
                        name: "FK_ActionAuthorization_Actions_ActionsId",
                        column: x => x.ActionsId,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActionAuthorization_Authorizations_AuthorizationsRoleId",
                        column: x => x.AuthorizationsRoleId,
                        principalTable: "Authorizations",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorizationController",
                columns: table => new
                {
                    AuthorizationsRoleId = table.Column<int>(type: "int", nullable: false),
                    ControllersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizationController", x => new { x.AuthorizationsRoleId, x.ControllersId });
                    table.ForeignKey(
                        name: "FK_AuthorizationController_Authorizations_AuthorizationsRoleId",
                        column: x => x.AuthorizationsRoleId,
                        principalTable: "Authorizations",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorizationController_Controllers_ControllersId",
                        column: x => x.ControllersId,
                        principalTable: "Controllers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorizationService",
                columns: table => new
                {
                    AuthorizationsRoleId = table.Column<int>(type: "int", nullable: false),
                    ServicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizationService", x => new { x.AuthorizationsRoleId, x.ServicesId });
                    table.ForeignKey(
                        name: "FK_AuthorizationService_Authorizations_AuthorizationsRoleId",
                        column: x => x.AuthorizationsRoleId,
                        principalTable: "Authorizations",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorizationService_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ControllerService",
                columns: table => new
                {
                    ServicesId = table.Column<int>(type: "int", nullable: false),
                    ServicesId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControllerService", x => new { x.ServicesId, x.ServicesId1 });
                    table.ForeignKey(
                        name: "FK_ControllerService_Controllers_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Controllers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ControllerService_Services_ServicesId1",
                        column: x => x.ServicesId1,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionAuthorization_AuthorizationsRoleId",
                table: "ActionAuthorization",
                column: "AuthorizationsRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorizationController_ControllersId",
                table: "AuthorizationController",
                column: "ControllersId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorizationService_ServicesId",
                table: "AuthorizationService",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_ControllerService_ServicesId1",
                table: "ControllerService",
                column: "ServicesId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionAuthorization");

            migrationBuilder.DropTable(
                name: "AuthorizationController");

            migrationBuilder.DropTable(
                name: "AuthorizationService");

            migrationBuilder.DropTable(
                name: "ControllerService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authorizations",
                table: "Authorizations");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Authorizations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ControllerId",
                table: "Authorizations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActionId",
                table: "Authorizations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authorizations",
                table: "Authorizations",
                columns: new[] { "RoleId", "ServiceId", "ControllerId", "ActionId" });

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
    }
}
