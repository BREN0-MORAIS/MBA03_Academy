using Academy.GestaoConteudo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Academy.GestaoConteudo.Data.Mappings;

public class CursoMapping : IEntityTypeConfiguration<Curso>
{
    public void Configure(EntityTypeBuilder<Curso> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Titulo)
            .IsRequired()
            .HasColumnType("Varchar(250)");

        builder.Property(c => c.Descricao)
         .IsRequired()
         .HasColumnType("Varchar(500)");

        builder.Property(c => c.Status)
                .IsRequired()
                .HasColumnType("int");

        builder.HasMany(c => c.Aulas)
             .WithOne(a => a.Curso)
             .HasForeignKey(c => c.CursoId);

        builder.OwnsOne(c => c.ConteudoProgramatico, cm =>
        {
            cm.Property(c => c.Objetivo)
                .HasColumnName("Objetivo")
                .HasColumnType("Varchar(500)");

            cm.Property(c => c.PreRequisitos)
             .HasColumnName("PreRequisitos")
             .HasColumnType("Varchar(500)");
        });

        builder.ToTable("Cursos");
    }

}
