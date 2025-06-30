using Academy.GestaoAlunos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

public class CertificadoMapping : IEntityTypeConfiguration<Certificado>
{
    public void Configure(EntityTypeBuilder<Certificado> builder)
    {
        builder.ToTable("Certificados");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .IsRequired()
            // SQLite não tem uniqueidentifier, EF Core trata Guid como TEXT, não precisa de HasColumnType aqui.
            ;

        builder.Property(c => c.UserId)
            .IsRequired();

        builder.Property(c => c.CursoId)
            .IsRequired();

        builder.Property(c => c.NomeDoAluno)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("TEXT"); // força o SQLite a entender que é texto

        builder.Property(c => c.TituloDoCurso)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnType("TEXT");

        builder.Property(c => c.DataEmissao)
            .IsRequired()
            .HasColumnType("TEXT"); // para datas em SQLite

        builder.Property(c => c.CodigoVerificacao)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("TEXT");

        builder.Property(c => c.DataCadastro)
            .IsRequired()
            .HasColumnType("TEXT");

        builder.Property(c => c.DataAtualizacao)
            .IsRequired()
            .HasColumnType("TEXT");

        //builder.HasOne(c => c.Matricula)
        //    .WithOne() // ou .WithMany(m => m.Certificados), se for 1:N
        //    .HasForeignKey<Certificado>(c => c.MatriculaId)
        //    .OnDelete(DeleteBehavior.Restrict);
    }
}
