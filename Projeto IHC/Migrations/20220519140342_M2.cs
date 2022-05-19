using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_IHC.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SESSOES_USUARIOS_UsuarioId",
                table: "SESSOES");

            migrationBuilder.DropIndex(
                name: "IX_SESSOES_UsuarioId",
                table: "SESSOES");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "SESSOES");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "SESSOES");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "USUARIOS",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaVezOnline",
                table: "USUARIOS",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DiasSemana",
                table: "SESSOES",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Horario",
                table: "SESSOES",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "emBreve",
                table: "FILMES",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "emCartaz",
                table: "FILMES",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_SESSOES_FilmeId",
                table: "SESSOES",
                column: "FilmeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SESSOES_FILMES_FilmeId",
                table: "SESSOES",
                column: "FilmeId",
                principalTable: "FILMES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SESSOES_FILMES_FilmeId",
                table: "SESSOES");

            migrationBuilder.DropIndex(
                name: "IX_SESSOES_FilmeId",
                table: "SESSOES");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "UltimaVezOnline",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "DiasSemana",
                table: "SESSOES");

            migrationBuilder.DropColumn(
                name: "Horario",
                table: "SESSOES");

            migrationBuilder.DropColumn(
                name: "emBreve",
                table: "FILMES");

            migrationBuilder.DropColumn(
                name: "emCartaz",
                table: "FILMES");

            migrationBuilder.AddColumn<int>(
                name: "CPF",
                table: "USUARIOS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "USUARIOS",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "SESSOES",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "SESSOES",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SESSOES_UsuarioId",
                table: "SESSOES",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_SESSOES_USUARIOS_UsuarioId",
                table: "SESSOES",
                column: "UsuarioId",
                principalTable: "USUARIOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
