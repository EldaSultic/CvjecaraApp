using Microsoft.EntityFrameworkCore.Migrations;

namespace Posiljka.Data.Migrations
{
    public partial class _1147 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Stavka_VrstaCvijeta_VrstaCvijetaId",
                table: "Narudzba_Stavka");

            migrationBuilder.DropColumn(
                name: "Poruka",
                table: "Narudzba_Stavka");

            migrationBuilder.AlterColumn<int>(
                name: "VrstaCvijetaId",
                table: "Narudzba_Stavka",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "NarudzbaId",
                table: "Narudzba_Stavka",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_Stavka_NarudzbaId",
                table: "Narudzba_Stavka",
                column: "NarudzbaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Stavka_Narudzba_NarudzbaId",
                table: "Narudzba_Stavka",
                column: "NarudzbaId",
                principalTable: "Narudzba",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Stavka_VrstaCvijeta_VrstaCvijetaId",
                table: "Narudzba_Stavka",
                column: "VrstaCvijetaId",
                principalTable: "VrstaCvijeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Stavka_Narudzba_NarudzbaId",
                table: "Narudzba_Stavka");

            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Stavka_VrstaCvijeta_VrstaCvijetaId",
                table: "Narudzba_Stavka");

            migrationBuilder.DropIndex(
                name: "IX_Narudzba_Stavka_NarudzbaId",
                table: "Narudzba_Stavka");

            migrationBuilder.DropColumn(
                name: "NarudzbaId",
                table: "Narudzba_Stavka");

            migrationBuilder.AlterColumn<int>(
                name: "VrstaCvijetaId",
                table: "Narudzba_Stavka",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Poruka",
                table: "Narudzba_Stavka",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Stavka_VrstaCvijeta_VrstaCvijetaId",
                table: "Narudzba_Stavka",
                column: "VrstaCvijetaId",
                principalTable: "VrstaCvijeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
