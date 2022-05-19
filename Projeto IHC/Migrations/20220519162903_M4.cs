using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_IHC.Migrations
{
    public partial class M4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Classificação",
                table: "FILMES",
                newName: "Duracao");

            migrationBuilder.AddColumn<string>(
                name: "Classificacao",
                table: "FILMES",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Classificacao",
                table: "FILMES");

            migrationBuilder.RenameColumn(
                name: "Duracao",
                table: "FILMES",
                newName: "Classificação");
        }
    }
}
