using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscoverAirline.Security.Rule.Migrations
{
    public partial class refactorInAuthorizationTables_202110183116 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControllerActions");

            migrationBuilder.DropTable(
                name: "RoleServices");

            migrationBuilder.DropTable(
                name: "ServiceControllers");

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

            migrationBuilder.CreateTable(
                name: "Authorizations",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ControllerId = table.Column<int>(type: "int", nullable: false),
                    ActionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authorizations", x => new { x.RoleId, x.ServiceId, x.ControllerId, x.ActionId });
                    table.ForeignKey(
                        name: "FK_Authorizations_Actions_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Authorizations_Controllers_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Controllers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Authorizations_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Authorizations_Services_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Services",
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
                name: "FK_Controllers_Services_ServiceId",
                table: "Controllers",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Controllers_Services_ServiceId",
                table: "Controllers");

            migrationBuilder.DropTable(
                name: "ActionController");

            migrationBuilder.DropTable(
                name: "Authorizations");

            migrationBuilder.DropIndex(
                name: "IX_Controllers_ServiceId",
                table: "Controllers");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Controllers");

            migrationBuilder.CreateTable(
                name: "ControllerActions",
                columns: table => new
                {
                    ActionId = table.Column<int>(type: "int", nullable: false),
                    ControllerId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControllerActions", x => new { x.ActionId, x.ControllerId });
                    table.ForeignKey(
                        name: "FK_ControllerActions_Actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ControllerActions_Controllers_ControllerId",
                        column: x => x.ControllerId,
                        principalTable: "Controllers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleServices",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleServices", x => new { x.RoleId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_RoleServices_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceControllers",
                columns: table => new
                {
                    ControllerId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceControllers", x => new { x.ControllerId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_ServiceControllers_Controllers_ControllerId",
                        column: x => x.ControllerId,
                        principalTable: "Controllers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceControllers_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControllerActions_ControllerId",
                table: "ControllerActions",
                column: "ControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleServices_ServiceId",
                table: "RoleServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceControllers_ServiceId",
                table: "ServiceControllers",
                column: "ServiceId");
        }
    }
}
