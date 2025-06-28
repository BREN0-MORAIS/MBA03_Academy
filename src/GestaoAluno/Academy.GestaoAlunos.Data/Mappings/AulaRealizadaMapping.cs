using Academy.GestaoAlunos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.GestaoAlunos.Data.Mappings;

public class AulaRealizadaMapping : IEntityTypeConfiguration<AulaRealizada>
{
    public void Configure(EntityTypeBuilder<AulaRealizada> builder)
    {
        builder.HasKey(a=> a.Id);

        builder.HasOne(ar => ar.Matricula)
            .WithMany(m => m.AulasRealizadas)
            .HasForeignKey(ar => ar.MatriculaId);

        builder.ToTable("AulaRealizadas");
    }
}
