using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscoverAirline.Security.Rule.Migrations
{
    public partial class addTableManyToManyFromAuthorizations_202110204411 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionAuthorization_Authorizations_AuthorizationsRoleId",
                table: "ActionAuthorization");

            migrationBuilder.DropTable(
                name: "ActionController");

            migrationBuilder.DropTable(
                name: "AuthorizationController");

            migrationBuilder.DropTable(
                name: "AuthorizationService");

            migrationBuilder.DropTable(
                name: "ControllerService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authorizations",
                table: "Authorizations");

            migrationBuilder.RenameColumn(
                name: "AuthorizationsRoleId",
                table: "ActionAuthorization",
                newName: "AuthorizationsId");

            migrationBuilder.RenameIndex(
                name: "IX_ActionAuthorization_AuthorizationsRoleId",
                table: "ActionAuthorization",
                newName: "IX_ActionAuthorization_AuthorizationsId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Authorizations",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Authorizations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ControllerId",
                table: "Authorizations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Authorizations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Authorizations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Authorizations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authorizations",
                table: "Authorizations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Authorizations_ControllerId",
                table: "Authorizations",
                column: "ControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_Authorizations_RoleId",
                table: "Authorizations",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Authorizations_ServiceId",
                table: "Authorizations",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionAuthorization_Authorizations_AuthorizationsId",
                table: "ActionAuthorization",
                column: "AuthorizationsId",
                principalTable: "Authorizations",
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
                name: "FK_ActionAuthorization_Authorizations_AuthorizationsId",
                table: "ActionAuthorization");

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
                name: "IX_Authorizations_ControllerId",
                table: "Authorizations");

            migrationBuilder.DropIndex(
                name: "IX_Authorizations_RoleId",
                table: "Authorizations");

            migrationBuilder.DropIndex(
                name: "IX_Authorizations_ServiceId",
                table: "Authorizations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Authorizations");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Authorizations");

            migrationBuilder.DropColumn(
                name: "ControllerId",
                table: "Authorizations");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Authorizations");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Authorizations");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Authorizations");

            migrationBuilder.RenameColumn(
                name: "AuthorizationsId",
                table: "ActionAuthorization",
                newName: "AuthorizationsRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_ActionAuthorization_AuthorizationsId",
                table: "ActionAuthorization",
                newName: "IX_ActionAuthorization_AuthorizationsRoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authorizations",
                table: "Authorizations",
                column: "RoleId");

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
                name: "IX_ActionController_ControllersId",
                table: "ActionController",
                column: "ControllersId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ActionAuthorization_Authorizations_AuthorizationsRoleId",
                table: "ActionAuthorization",
                column: "AuthorizationsRoleId",
                principalTable: "Authorizations",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
