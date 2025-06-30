using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academy.GestaoAlunos.Data.Migrations
{
    /// <inheritdoc />
    public partial class GestaoAlunosSqlite6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificados_Matriculas_MatriculaId",
                table: "Certificados");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificados_Matriculas_MatriculaId1",
                table: "Certificados");

            migrationBuilder.DropIndex(
                name: "IX_Certificados_MatriculaId1",
                table: "Certificados");

            migrationBuilder.DropColumn(
                name: "MatriculaId1",
                table: "Certificados");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificados_Matriculas_MatriculaId",
                table: "Certificados",
                column: "MatriculaId",
                principalTable: "Matriculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificados_Matriculas_MatriculaId",
                table: "Certificados");

            migrationBuilder.AddColumn<Guid>(
                name: "MatriculaId1",
                table: "Certificados",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Certificados_MatriculaId1",
                table: "Certificados",
                column: "MatriculaId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificados_Matriculas_MatriculaId",
                table: "Certificados",
                column: "MatriculaId",
                principalTable: "Matriculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificados_Matriculas_MatriculaId1",
                table: "Certificados",
                column: "MatriculaId1",
                principalTable: "Matriculas",
                principalColumn: "Id");
        }
    }
}
