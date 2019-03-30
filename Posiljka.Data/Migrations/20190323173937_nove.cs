using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Posiljka.Data.Migrations
{
    public partial class nove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Ukras_UkrasId",
                table: "Narudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_VrstaCvijeta_VrstaCvijetaId",
                table: "Narudzba");

            migrationBuilder.DropIndex(
                name: "IX_Narudzba_UkrasId",
                table: "Narudzba");

            migrationBuilder.DropIndex(
                name: "IX_Narudzba_VrstaCvijetaId",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "KolicinaCvjetova",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "Poruka",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "UkrasId",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "VrstaCvijetaId",
                table: "Narudzba");

            migrationBuilder.AddColumn<int>(
                name: "TopPonudaId",
                table: "Narudzba",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Narudzba_Stavka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VrstaCvijetaId = table.Column<int>(nullable: false),
                    UkrasId = table.Column<int>(nullable: true),
                    KolicinaCvjetova = table.Column<int>(nullable: false),
                    KolicinaUkrasa = table.Column<int>(nullable: true),
                    Poruka = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba_Stavka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Narudzba_Stavka_Ukras_UkrasId",
                        column: x => x.UkrasId,
                        principalTable: "Ukras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Narudzba_Stavka_VrstaCvijeta_VrstaCvijetaId",
                        column: x => x.VrstaCvijetaId,
                        principalTable: "VrstaCvijeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_TopPonudaId",
                table: "Narudzba",
                column: "TopPonudaId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_Stavka_UkrasId",
                table: "Narudzba_Stavka",
                column: "UkrasId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_Stavka_VrstaCvijetaId",
                table: "Narudzba_Stavka",
                column: "VrstaCvijetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_TopPonuda_TopPonudaId",
                table: "Narudzba",
                column: "TopPonudaId",
                principalTable: "TopPonuda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_TopPonuda_TopPonudaId",
                table: "Narudzba");

            migrationBuilder.DropTable(
                name: "Narudzba_Stavka");

            migrationBuilder.DropIndex(
                name: "IX_Narudzba_TopPonudaId",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "TopPonudaId",
                table: "Narudzba");

            migrationBuilder.AddColumn<int>(
                name: "KolicinaCvjetova",
                table: "Narudzba",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Poruka",
                table: "Narudzba",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UkrasId",
                table: "Narudzba",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VrstaCvijetaId",
                table: "Narudzba",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_UkrasId",
                table: "Narudzba",
                column: "UkrasId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_VrstaCvijetaId",
                table: "Narudzba",
                column: "VrstaCvijetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Ukras_UkrasId",
                table: "Narudzba",
                column: "UkrasId",
                principalTable: "Ukras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_VrstaCvijeta_VrstaCvijetaId",
                table: "Narudzba",
                column: "VrstaCvijetaId",
                principalTable: "VrstaCvijeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
