using Academy.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Academy.Core.Data.Repository;
public class Repository<T> : IRepository<T> where T : class, IAggregateRoot, new()
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public IUnitOfWork UnitOfWork => throw new NotImplementedException();

    public Repository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> ObterTodos()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<IEnumerable<T>> ObterTodos(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        foreach (var include in includes)
        {
            query = query.Include(include);
        }


        return await query.ToListAsync();
    }


    public async Task<T?> ObterPorId(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T?> ObterPorId(Guid id, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id);
    }

    public async Task<T> Adicionar(T entidade)
    {
        await _dbSet.AddAsync(entidade);
        await SalvarAsync();
        return entidade;
    }

    public void Atualizar(T entidade)
    {
        _dbSet.Update(entidade);
        _context.SaveChanges();
    }

    public async Task SalvarAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<T> ObterEntidadePorFiltro(Expression<Func<T, bool>> expression)
        =>  await  _dbSet.Where(expression).FirstOrDefaultAsync();
    
    public async Task<IEnumerable<T>> ObterListaEntidadePorFiltro(Expression<Func<T, bool>> expression) 
        =>  await _dbSet.Where(expression).ToListAsync();

    public void Dispose()
    {
        _context?.Dispose();
        GC.SuppressFinalize(this); // Opcional: previne chamada do finalizador
    }
}
