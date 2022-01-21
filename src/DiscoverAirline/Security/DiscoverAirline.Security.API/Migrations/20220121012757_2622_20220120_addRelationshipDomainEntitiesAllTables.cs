using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscoverAirline.Security.API.Migrations
{
    public partial class _2622_20220120_addRelationshipDomainEntitiesAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Users_UserId1",
                table: "UserTokens");

            migrationBuilder.DropIndex(
                name: "IX_UserTokens_UserId1",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accesses",
                table: "Accesses");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserTokens");

            migrationBuilder.RenameTable(
                name: "Accesses",
                newName: "Accessess");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserTokens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "UserTokens",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiryDate",
                table: "UserTokens",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(96)",
                maxLength: 96,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Roles",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(96)",
                maxLength: 96,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AccessId",
                table: "Policies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "Policies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Policies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Applications",
                type: "nvarchar(96)",
                maxLength: 96,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Actions",
                type: "nvarchar(96)",
                maxLength: 96,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Accessess",
                type: "nvarchar(96)",
                maxLength: 96,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "Accessess",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accessess",
                table: "Accessess",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ActionPolicy",
                columns: table => new
                {
                    ActionsId = table.Column<int>(type: "int", nullable: false),
                    PoliciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionPolicy", x => new { x.ActionsId, x.PoliciesId });
                    table.ForeignKey(
                        name: "FK_ActionPolicy_Actions_ActionsId",
                        column: x => x.ActionsId,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActionPolicy_Policies_PoliciesId",
                        column: x => x.PoliciesId,
                        principalTable: "Policies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleUser_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId",
                table: "UserTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_AccessId",
                table: "Policies",
                column: "AccessId");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_ApplicationId",
                table: "Policies",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_RoleId",
                table: "Policies",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessess_ApplicationId",
                table: "Accessess",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionPolicy_PoliciesId",
                table: "ActionPolicy",
                column: "PoliciesId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersId",
                table: "RoleUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accessess_Applications_ApplicationId",
                table: "Accessess",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Policies_Accessess_AccessId",
                table: "Policies",
                column: "AccessId",
                principalTable: "Accessess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Policies_Applications_ApplicationId",
                table: "Policies",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Policies_Roles_RoleId",
                table: "Policies",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accessess_Applications_ApplicationId",
                table: "Accessess");

            migrationBuilder.DropForeignKey(
                name: "FK_Policies_Accessess_AccessId",
                table: "Policies");

            migrationBuilder.DropForeignKey(
                name: "FK_Policies_Applications_ApplicationId",
                table: "Policies");

            migrationBuilder.DropForeignKey(
                name: "FK_Policies_Roles_RoleId",
                table: "Policies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens");

            migrationBuilder.DropTable(
                name: "ActionPolicy");

            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropIndex(
                name: "IX_UserTokens_UserId",
                table: "UserTokens");

            migrationBuilder.DropIndex(
                name: "IX_Policies_AccessId",
                table: "Policies");

            migrationBuilder.DropIndex(
                name: "IX_Policies_ApplicationId",
                table: "Policies");

            migrationBuilder.DropIndex(
                name: "IX_Policies_RoleId",
                table: "Policies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accessess",
                table: "Accessess");

            migrationBuilder.DropIndex(
                name: "IX_Accessess_ApplicationId",
                table: "Accessess");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AccessId",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Accessess");

            migrationBuilder.RenameTable(
                name: "Accessess",
                newName: "Accesses");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserTokens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "UserTokens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiryDate",
                table: "UserTokens",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "UserTokens",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Actions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(96)",
                oldMaxLength: 96);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Accesses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(96)",
                oldMaxLength: 96);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accesses",
                table: "Accesses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId1",
                table: "UserTokens",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Users_UserId1",
                table: "UserTokens",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
