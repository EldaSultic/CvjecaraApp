using Microsoft.EntityFrameworkCore.Migrations;

namespace Posiljka.Data.Migrations
{
    public partial class _1351 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Boja",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Naziv",
                table: "Boja",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
