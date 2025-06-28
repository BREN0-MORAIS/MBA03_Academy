using Academy.GestaoAlunos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.GestaoAlunos.Data.Mappings;

public class ProgressoAlunoCursoMapping : IEntityTypeConfiguration<ProgressoAlunoCurso>
{
    public void Configure(EntityTypeBuilder<ProgressoAlunoCurso> builder)
    {
        builder.HasKey(c => c.Id);


        builder.ToTable("ProgressoAlunoCursos");
    }
}
