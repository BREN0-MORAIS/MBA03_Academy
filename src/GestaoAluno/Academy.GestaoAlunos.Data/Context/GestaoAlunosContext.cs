using Academy.Core.Events.Messages;
using Academy.GestaoAlunos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.GestaoAlunos.Data.Context;

public class GestaoAlunosContext : DbContext
{
    public GestaoAlunosContext(DbContextOptions<GestaoAlunosContext> options) : base(options) { }

    public DbSet<AulaRealizada> AulasRealizadas { get; set; }
    public DbSet<Certificado> Certificados { get; set; }
    public DbSet<Matricula> Matriculas { get; set; }
    public DbSet<ProgressoAluno> ProgressoAlunos { get; set; }
    public DbSet<ProgressoAlunoCurso> ProgressoCursos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
        //    e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
        //    property.Relational().ColumnType = "varchar(100)";

        modelBuilder.Ignore<Event>();

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GestaoAlunosContext).Assembly);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries()
                    .Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
        {
            if (entry.State == EntityState.Added)
                entry.Property("DataCadastro").CurrentValue = DateTime.Now;

            if (entry.State == EntityState.Modified)
            {
                entry.Property("DataCadastro").IsModified = false;
                entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
    public async Task<bool> Commit()
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("DataCadastro").CurrentValue = DateTime.Now;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("DataCadastro").IsModified = false;
            }
        }

        return await base.SaveChangesAsync() > 0;
    }
}
