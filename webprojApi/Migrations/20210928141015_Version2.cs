using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webproj.Migrations
{
    public partial class Version2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Turniri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zemlja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pocetak = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Kraj = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turniri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vreme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Trajanje = table.Column<int>(type: "int", nullable: false),
                    Ishod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeliSahistaId = table.Column<int>(type: "int", nullable: true),
                    CrniSahistaId = table.Column<int>(type: "int", nullable: true),
                    TurnirId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partije_Sahisti_BeliSahistaId",
                        column: x => x.BeliSahistaId,
                        principalTable: "Sahisti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partije_Sahisti_CrniSahistaId",
                        column: x => x.CrniSahistaId,
                        principalTable: "Sahisti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partije_Turniri_TurnirId",
                        column: x => x.TurnirId,
                        principalTable: "Turniri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partije_BeliSahistaId",
                table: "Partije",
                column: "BeliSahistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Partije_CrniSahistaId",
                table: "Partije",
                column: "CrniSahistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Partije_TurnirId",
                table: "Partije",
                column: "TurnirId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partije");

            migrationBuilder.DropTable(
                name: "Turniri");
        }
    }
}
