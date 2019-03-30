using Microsoft.EntityFrameworkCore.Migrations;

namespace Posiljka.Data.Migrations
{
    public partial class _2128 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "prezime",
                table: "Narudzba",
                newName: "prezimePrimaoca");

            migrationBuilder.RenameColumn(
                name: "ime",
                table: "Narudzba",
                newName: "imePrimaoca");

            migrationBuilder.RenameColumn(
                name: "adresa",
                table: "Narudzba",
                newName: "adresaPrimaoca");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "prezimePrimaoca",
                table: "Narudzba",
                newName: "prezime");

            migrationBuilder.RenameColumn(
                name: "imePrimaoca",
                table: "Narudzba",
                newName: "ime");

            migrationBuilder.RenameColumn(
                name: "adresaPrimaoca",
                table: "Narudzba",
                newName: "adresa");
        }
    }
}
