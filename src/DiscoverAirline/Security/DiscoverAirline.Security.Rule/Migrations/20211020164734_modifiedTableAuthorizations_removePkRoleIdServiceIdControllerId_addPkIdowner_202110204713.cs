using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscoverAirline.Security.Rule.Migrations
{
    public partial class modifiedTableAuthorizations_removePkRoleIdServiceIdControllerId_addPkIdowner_202110204713 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionAuthorization_Authorizations_AuthorizationsRoleId_AuthorizationsServiceId_AuthorizationsControllerId",
                table: "ActionAuthorization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authorizations",
                table: "Authorizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActionAuthorization",
                table: "ActionAuthorization");

            migrationBuilder.DropIndex(
                name: "IX_ActionAuthorization_AuthorizationsRoleId_AuthorizationsServiceId_AuthorizationsControllerId",
                table: "ActionAuthorization");

            migrationBuilder.DropColumn(
                name: "AuthorizationsRoleId",
                table: "ActionAuthorization");

            migrationBuilder.DropColumn(
                name: "AuthorizationsServiceId",
                table: "ActionAuthorization");

            migrationBuilder.RenameColumn(
                name: "AuthorizationsControllerId",
                table: "ActionAuthorization",
                newName: "AuthorizationsId");

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

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Authorizations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Authorizations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authorizations",
                table: "Authorizations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActionAuthorization",
                table: "ActionAuthorization",
                columns: new[] { "ActionsId", "AuthorizationsId" });

            migrationBuilder.CreateIndex(
                name: "IX_Authorizations_RoleId",
                table: "Authorizations",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionAuthorization_AuthorizationsId",
                table: "ActionAuthorization",
                column: "AuthorizationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionAuthorization_Authorizations_AuthorizationsId",
                table: "ActionAuthorization",
                column: "AuthorizationsId",
                principalTable: "Authorizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionAuthorization_Authorizations_AuthorizationsId",
                table: "ActionAuthorization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authorizations",
                table: "Authorizations");

            migrationBuilder.DropIndex(
                name: "IX_Authorizations_RoleId",
                table: "Authorizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActionAuthorization",
                table: "ActionAuthorization");

            migrationBuilder.DropIndex(
                name: "IX_ActionAuthorization_AuthorizationsId",
                table: "ActionAuthorization");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Authorizations");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Authorizations");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Authorizations");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Authorizations");

            migrationBuilder.RenameColumn(
                name: "AuthorizationsId",
                table: "ActionAuthorization",
                newName: "AuthorizationsControllerId");

            migrationBuilder.AddColumn<int>(
                name: "AuthorizationsRoleId",
                table: "ActionAuthorization",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuthorizationsServiceId",
                table: "ActionAuthorization",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authorizations",
                table: "Authorizations",
                columns: new[] { "RoleId", "ServiceId", "ControllerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActionAuthorization",
                table: "ActionAuthorization",
                columns: new[] { "ActionsId", "AuthorizationsRoleId", "AuthorizationsServiceId", "AuthorizationsControllerId" });

            migrationBuilder.CreateIndex(
                name: "IX_ActionAuthorization_AuthorizationsRoleId_AuthorizationsServiceId_AuthorizationsControllerId",
                table: "ActionAuthorization",
                columns: new[] { "AuthorizationsRoleId", "AuthorizationsServiceId", "AuthorizationsControllerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActionAuthorization_Authorizations_AuthorizationsRoleId_AuthorizationsServiceId_AuthorizationsControllerId",
                table: "ActionAuthorization",
                columns: new[] { "AuthorizationsRoleId", "AuthorizationsServiceId", "AuthorizationsControllerId" },
                principalTable: "Authorizations",
                principalColumns: new[] { "RoleId", "ServiceId", "ControllerId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
