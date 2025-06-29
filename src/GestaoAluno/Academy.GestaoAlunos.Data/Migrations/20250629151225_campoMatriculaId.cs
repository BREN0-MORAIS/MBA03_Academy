using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academy.GestaoAlunos.Data.Migrations
{
    /// <inheritdoc />
    public partial class campoMatriculaId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MatriculaId",
                table: "ProgressoAlunoCursos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ProgressoAlunoCursos_MatriculaId",
                table: "ProgressoAlunoCursos",
                column: "MatriculaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressoAlunoCursos_Matriculas_MatriculaId",
                table: "ProgressoAlunoCursos",
                column: "MatriculaId",
                principalTable: "Matriculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgressoAlunoCursos_Matriculas_MatriculaId",
                table: "ProgressoAlunoCursos");

            migrationBuilder.DropIndex(
                name: "IX_ProgressoAlunoCursos_MatriculaId",
                table: "ProgressoAlunoCursos");

            migrationBuilder.DropColumn(
                name: "MatriculaId",
                table: "ProgressoAlunoCursos");
        }
    }
}
