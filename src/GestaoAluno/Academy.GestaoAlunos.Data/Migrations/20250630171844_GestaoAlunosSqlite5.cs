using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academy.GestaoAlunos.Data.Migrations
{
    /// <inheritdoc />
    public partial class GestaoAlunosSqlite5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgressoAlunos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    TotalCursosConcluidos = table.Column<int>(type: "int", nullable: false),
                    TotalHoras = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressoAlunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AulaRealizadas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MatriculaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AulaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AulaRealizadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AulaRealizadas_Matriculas_MatriculaId",
                        column: x => x.MatriculaId,
                        principalTable: "Matriculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MatriculaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    NomeDoAluno = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TituloDoCurso = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CodigoVerificacao = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    MatriculaId1 = table.Column<Guid>(type: "TEXT", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificados_Matriculas_MatriculaId",
                        column: x => x.MatriculaId,
                        principalTable: "Matriculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Certificados_Matriculas_MatriculaId1",
                        column: x => x.MatriculaId1,
                        principalTable: "Matriculas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProgressoAlunoCursos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MatriculaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Progresso = table.Column<decimal>(type: "TEXT", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressoAlunoCursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgressoAlunoCursos_Matriculas_MatriculaId",
                        column: x => x.MatriculaId,
                        principalTable: "Matriculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AulaRealizadas_MatriculaId",
                table: "AulaRealizadas",
                column: "MatriculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificados_MatriculaId",
                table: "Certificados",
                column: "MatriculaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Certificados_MatriculaId1",
                table: "Certificados",
                column: "MatriculaId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProgressoAlunoCursos_MatriculaId",
                table: "ProgressoAlunoCursos",
                column: "MatriculaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AulaRealizadas");

            migrationBuilder.DropTable(
                name: "Certificados");

            migrationBuilder.DropTable(
                name: "ProgressoAlunoCursos");

            migrationBuilder.DropTable(
                name: "ProgressoAlunos");

            migrationBuilder.DropTable(
                name: "Matriculas");
        }
    }
}
