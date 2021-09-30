using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webproj.Migrations
{
    public partial class Version6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kraj",
                table: "Turniri");

            migrationBuilder.DropColumn(
                name: "Pocetak",
                table: "Turniri");

            migrationBuilder.DropColumn(
                name: "Broj",
                table: "Sahisti");

            migrationBuilder.DropColumn(
                name: "Grad",
                table: "Sahisti");

            migrationBuilder.DropColumn(
                name: "Ulica",
                table: "Sahisti");

            migrationBuilder.DropColumn(
                name: "Datum",
                table: "Partije");

            migrationBuilder.DropColumn(
                name: "Vreme",
                table: "Partije");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Kraj",
                table: "Turniri",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Pocetak",
                table: "Turniri",
                type: "datetime2",
                maxLength: 255,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Broj",
                table: "Sahisti",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grad",
                table: "Sahisti",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ulica",
                table: "Sahisti",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Datum",
                table: "Partije",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Vreme",
                table: "Partije",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
