using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backendopexlaunchpad.Migrations
{
    /// <inheritdoc />
    public partial class AddSlugToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccessPath",
                table: "UserProducts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "UserProducts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserProducts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UserProducts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Slug",
                value: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Slug",
                value: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Slug",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessPath",
                table: "UserProducts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "UserProducts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserProducts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UserProducts");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Products");
        }
    }
}
