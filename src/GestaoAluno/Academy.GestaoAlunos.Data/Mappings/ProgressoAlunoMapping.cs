using Academy.GestaoAlunos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.GestaoAlunos.Data.Mappings;

public class ProgressoAlunoMapping : IEntityTypeConfiguration<ProgressoAluno>
{
    public void Configure(EntityTypeBuilder<ProgressoAluno> builder)
    {
        builder.HasKey(h => h.Id);

        builder.OwnsOne(h => h.HistoricoAprendizado, ha =>
            {
                ha.Property(h => h.TotalCursosConcluidos)
                    .HasColumnName("TotalCursosConcluidos")
                    .HasColumnType("int");

                ha.Property(h => h.TotalHoras)
                  .HasColumnName("TotalHoras")
                  .HasColumnType("int");
            });

        builder.ToTable("ProgressoAlunos");
    }
}
