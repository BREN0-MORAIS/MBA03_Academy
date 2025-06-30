using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academy.PagamentoFaturamento.Data.Migrations
{
    /// <inheritdoc />
    public partial class PagamentoFaturamentoSqlite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MatriculaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StatusPagamento = table.Column<int>(type: "INTEGER", nullable: false),
                    MeioPagamento = table.Column<int>(type: "INTEGER", nullable: false),
                    TransacaoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    NomeTitular = table.Column<string>(type: "varchar(200)", nullable: false),
                    CartaoFinal = table.Column<string>(type: "varchar(4)", nullable: false),
                    Bandeira = table.Column<string>(type: "varchar(20)", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MensagemGateway = table.Column<string>(type: "varchar(200)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagamentos");
        }
    }
}
