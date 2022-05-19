using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_IHC.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Classificação",
                table: "FILMES",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Classificação",
                table: "FILMES");
        }
    }
}
