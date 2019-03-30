using Microsoft.EntityFrameworkCore.Migrations;

namespace Posiljka.Data.Migrations
{
    public partial class _1846 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Korisnik_KorisnikId",
                table: "Narudzba");

            migrationBuilder.RenameColumn(
                name: "KorisnikId",
                table: "Narudzba",
                newName: "KorisnickiNalogId");

            migrationBuilder.RenameIndex(
                name: "IX_Narudzba_KorisnikId",
                table: "Narudzba",
                newName: "IX_Narudzba_KorisnickiNalogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_KorisnickiNalog_KorisnickiNalogId",
                table: "Narudzba",
                column: "KorisnickiNalogId",
                principalTable: "KorisnickiNalog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_KorisnickiNalog_KorisnickiNalogId",
                table: "Narudzba");

            migrationBuilder.RenameColumn(
                name: "KorisnickiNalogId",
                table: "Narudzba",
                newName: "KorisnikId");

            migrationBuilder.RenameIndex(
                name: "IX_Narudzba_KorisnickiNalogId",
                table: "Narudzba",
                newName: "IX_Narudzba_KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Korisnik_KorisnikId",
                table: "Narudzba",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
