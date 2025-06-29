using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academy.PagamentoFaturamento.Data.Migrations
{
    /// <inheritdoc />
    public partial class NomeTitular : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeTitular",
                table: "Pagamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeTitular",
                table: "Pagamentos");
        }
    }
}
