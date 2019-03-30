using Microsoft.EntityFrameworkCore.Migrations;

namespace Posiljka.Data.Migrations
{
    public partial class _1347 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrojKartice",
                table: "Narudzba",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatumUplate",
                table: "Narudzba",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Poruka",
                table: "Narudzba",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrojKartice",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "DatumUplate",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "Poruka",
                table: "Narudzba");
        }
    }
}
