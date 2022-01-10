using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscoverAirline.Security.Rule.Migrations
{
    public partial class addColumnAllTables_ColumnUpdateDateAndColumnActive_202110153311 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Tokens",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Tokens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Services",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Services",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "ServiceControllers",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "ServiceControllers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "RoleServices",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "RoleServices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessName",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Profiles",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Profiles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "ProfileRoles",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "ProfileRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Controllers",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Controllers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "ControllerActions",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "ControllerActions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Actions",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Actions",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "ServiceControllers");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "ServiceControllers");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "RoleServices");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "RoleServices");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "BusinessName",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "ProfileRoles");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "ProfileRoles");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Controllers");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Controllers");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "ControllerActions");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "ControllerActions");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Actions");
        }
    }
}
