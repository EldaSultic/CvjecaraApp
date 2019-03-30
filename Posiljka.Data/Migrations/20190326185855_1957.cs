using Microsoft.EntityFrameworkCore.Migrations;

namespace Posiljka.Data.Migrations
{
    public partial class _1957 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Stavka_VrstaCvijeta_VrstaCvijetaId",
                table: "Narudzba_Stavka");

            migrationBuilder.RenameColumn(
                name: "VrstaCvijetaId",
                table: "Narudzba_Stavka",
                newName: "VrstaCvijeta_BojaId");

            migrationBuilder.RenameIndex(
                name: "IX_Narudzba_Stavka_VrstaCvijetaId",
                table: "Narudzba_Stavka",
                newName: "IX_Narudzba_Stavka_VrstaCvijeta_BojaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Stavka_VrstaCvijeta_Boja_VrstaCvijeta_BojaId",
                table: "Narudzba_Stavka",
                column: "VrstaCvijeta_BojaId",
                principalTable: "VrstaCvijeta_Boja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Stavka_VrstaCvijeta_Boja_VrstaCvijeta_BojaId",
                table: "Narudzba_Stavka");

            migrationBuilder.RenameColumn(
                name: "VrstaCvijeta_BojaId",
                table: "Narudzba_Stavka",
                newName: "VrstaCvijetaId");

            migrationBuilder.RenameIndex(
                name: "IX_Narudzba_Stavka_VrstaCvijeta_BojaId",
                table: "Narudzba_Stavka",
                newName: "IX_Narudzba_Stavka_VrstaCvijetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Stavka_VrstaCvijeta_VrstaCvijetaId",
                table: "Narudzba_Stavka",
                column: "VrstaCvijetaId",
                principalTable: "VrstaCvijeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
