using Microsoft.EntityFrameworkCore.Migrations;

namespace Posiljka.Data.Migrations
{
    public partial class _1148 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "KolicinaCvjetova",
                table: "Narudzba_Stavka",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "KolicinaCvjetova",
                table: "Narudzba_Stavka",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
