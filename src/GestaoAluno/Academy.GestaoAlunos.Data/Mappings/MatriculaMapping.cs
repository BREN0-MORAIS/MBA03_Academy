using Academy.GestaoAlunos.Domain.Entities;
using Academy.GestaoAlunos.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.GestaoAlunos.Data.Mappings;

public class MatriculaMapping : IEntityTypeConfiguration<Matricula>
{
    public void Configure(EntityTypeBuilder<Matricula> builder)
    {
        builder.HasKey(c => c.Id);

        builder.ToTable("Matriculas");

    }
}
