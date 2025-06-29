using Academy.PagamentoFaturamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.PagamentoFaturamento.Data.Mappings;

public class PagamentoMapping : IEntityTypeConfiguration<Pagamento>
{
    public void Configure(EntityTypeBuilder<Pagamento> builder)
    {
        builder.ToTable("Pagamentos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.MatriculaId)
            .IsRequired();

        builder.Property(p => p.Valor)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(p => p.StatusPagamento)
            .HasConversion<int>() 
            .IsRequired();

        builder.Property(p => p.MeioPagamento)
            .HasConversion<int>() 
            .IsRequired();

        builder.Property(p => p.TransacaoId)
            .IsRequired();

        builder.Property(p => p.CartaoFinal)
            .HasColumnType("varchar(4)")
            .IsRequired();

        builder.Property(p => p.Bandeira)
            .HasColumnType("varchar(20)")
            .IsRequired();

        builder.Property(p => p.DataPagamento)
            .IsRequired();

        builder.Property(p => p.MensagemGateway)
            .HasColumnType("varchar(200)")
            .IsRequired();
    }
}
