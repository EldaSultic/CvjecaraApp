using Microsoft.EntityFrameworkCore.Migrations;

namespace Posiljka.Data.Migrations
{
    public partial class _2126 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "adresa",
                table: "Narudzba",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ime",
                table: "Narudzba",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "prezime",
                table: "Narudzba",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "Korisnik",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "adresa",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "ime",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "prezime",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "Korisnik");
        }
    }
}
