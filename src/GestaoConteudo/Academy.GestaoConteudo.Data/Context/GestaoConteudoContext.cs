using Academy.Core.Events.Messages;
using Academy.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Academy.GestaoConteudo.Data.Context;

public class GestaoConteudoContext : DbContext, IUnitOfWork
{
    public GestaoConteudoContext(DbContextOptions<GestaoConteudoContext> options)
         : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
        //    e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
        //    property.Relational().ColumnType = "varchar(100)";

        modelBuilder.Ignore<Event>();

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GestaoConteudoContext).Assembly);
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
