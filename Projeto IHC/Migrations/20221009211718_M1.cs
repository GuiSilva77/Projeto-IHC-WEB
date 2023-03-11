using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_IHC.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FILMES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URLPoster = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URLCapa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URLTrailer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diretor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ano = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resumo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmCartaz = table.Column<bool>(type: "bit", nullable: false),
                    EmBreve = table.Column<bool>(type: "bit", nullable: false),
                    Classificacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duracao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FILMES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaVezOnline = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SESSOES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmeId = table.Column<int>(type: "int", nullable: false),
                    Horario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiasSemana = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sala = table.Column<int>(type: "int", nullable: false),
                    Audio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SESSOES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SESSOES_FILMES_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "FILMES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SESSOES_FilmeId",
                table: "SESSOES",
                column: "FilmeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SESSOES");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropTable(
                name: "FILMES");
        }
    }
}
