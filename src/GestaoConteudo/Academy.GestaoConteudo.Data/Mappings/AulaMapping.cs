using Academy.GestaoConteudo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.GestaoConteudo.Data.Mappings;

public class AulaMapping : IEntityTypeConfiguration<Aula>
{
    public void Configure(EntityTypeBuilder<Aula> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Titulo)
       .IsRequired()
       .HasColumnType("Varchar(250)");

        builder.Property(c => c.Descricao)
       .IsRequired()
       .HasColumnType("Varchar(500)");


        builder.Property(c => c.VideoUrl)
       .IsRequired()
       .HasColumnType("Varchar(100)");

        builder.ToTable("Aulas");
    }
}
