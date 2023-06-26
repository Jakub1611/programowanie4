using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LasotaProjekt.Migrations
{
    /// <inheritdoc />
    public partial class nazwa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Przedmioty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaPrzedmiotu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodPrzedmiotu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Godziny = table.Column<int>(type: "int", nullable: false),
                    Kierunek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Semestr = table.Column<int>(type: "int", nullable: false),
                    TrybStud = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stopien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RokAkademicki = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Przedmioty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studenci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrIndeksu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rocznik = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grupy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KodGrupy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypGrupy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kierunek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Semestr = table.Column<int>(type: "int", nullable: false),
                    TrybStud = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stopien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grupy_Studenci_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Studenci",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PozycjePlanu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrzedmiotId = table.Column<int>(type: "int", nullable: false),
                    GrupaId = table.Column<int>(type: "int", nullable: false),
                    Dzien = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GodzinaOd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GodzinaDo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sala = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PozycjePlanu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PozycjePlanu_Grupy_GrupaId",
                        column: x => x.GrupaId,
                        principalTable: "Grupy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PozycjePlanu_Przedmioty_PrzedmiotId",
                        column: x => x.PrzedmiotId,
                        principalTable: "Przedmioty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grupy_StudentId",
                table: "Grupy",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_PozycjePlanu_GrupaId",
                table: "PozycjePlanu",
                column: "GrupaId");

            migrationBuilder.CreateIndex(
                name: "IX_PozycjePlanu_PrzedmiotId",
                table: "PozycjePlanu",
                column: "PrzedmiotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PozycjePlanu");

            migrationBuilder.DropTable(
                name: "Grupy");

            migrationBuilder.DropTable(
                name: "Przedmioty");

            migrationBuilder.DropTable(
                name: "Studenci");
        }
    }
}
