using Academy.GestaoConteudo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.GestaoConteudo.Data.Mappings
{
    public class AulaMapping : IEntityTypeConfiguration<Aula>
    {
        public void Configure(EntityTypeBuilder<Aula> builder)
        {
            builder.HasKey(c => c.Id);


            builder.Property(c => c.Titulo)
           .IsRequired()
           .HasColumnType("Varchar(50)");

            builder.ToTable("Aulas");

        }
    }
}
